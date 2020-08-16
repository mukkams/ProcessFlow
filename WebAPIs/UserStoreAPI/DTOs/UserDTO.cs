using System.ComponentModel.DataAnnotations;

namespace UserStoreAPI.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage ="You must specify password between 4 and 8 characters!!!")]
        public string Password { get; set; }
    }
}