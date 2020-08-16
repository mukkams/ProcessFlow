using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserStoreAPI.Models;

namespace UserStoreAPI.Data.UserStore
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;
        public AuthRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;

        }
        public async Task<User> Login(string username, string password)
        {
            var user= await this._dataContext.Users.FirstOrDefaultAsync( u => u.Username == username);

            if(user == null)
                return null;

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {                
                var computeHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computeHash.Length; i++)
                {
                    if(computeHash[i] != passwordHash[i])
                        return false;
                }
            }
            
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte [] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash= passwordHash;
            user.PasswordSalt= passwordSalt;

            await this._dataContext.Users.AddAsync(user);
            await this._dataContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt= hmac.Key;
                passwordHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await this._dataContext.Users.AnyAsync( u => u.Username == username))
                    return true;

            return false;
        }
    }
}