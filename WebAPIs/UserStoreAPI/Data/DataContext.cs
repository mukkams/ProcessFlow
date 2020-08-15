using Microsoft.EntityFrameworkCore;
using UserStoreAPI.Models;

namespace UserStoreAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set;}
        
    }
}