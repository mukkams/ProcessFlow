using System;
using UserStoreAPI.Data;

namespace UserStoreAPI.Models
{
    public class User 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
    }
}