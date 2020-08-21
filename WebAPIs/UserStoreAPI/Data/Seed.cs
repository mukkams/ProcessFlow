using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UserStoreAPI.Data;
using UserStoreAPI.Models;

namespace UserStoreAPI.Data
{
    public class Seed
    {
        private readonly DataContext _db;

        public Seed(DataContext db)
        {
            _db = db;
        }
        public void SeedUsers()
        {
            if (_db.Users.Any()) { return; }

            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var jsonUserData = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach (var user in jsonUserData)
            {
                byte[] passwordHash, passwordSalt;

                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _db.Users.Add(user);
            }

            _db.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}