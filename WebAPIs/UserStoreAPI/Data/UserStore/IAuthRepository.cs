using System.Threading.Tasks;
using UserStoreAPI.Models;

namespace UserStoreAPI.Data.UserStore
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);

         Task<User> Login(string username, string password);

         Task<bool> UserExists(string username);
    }
}