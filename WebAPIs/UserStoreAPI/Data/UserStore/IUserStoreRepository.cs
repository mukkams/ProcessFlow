using System.Collections.Generic;
using System.Threading.Tasks;
using UserStoreAPI.Models;

namespace UserStoreAPI.Data.UserStore
{
    public interface IUserStoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
    }
}