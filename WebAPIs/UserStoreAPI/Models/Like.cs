using System;

namespace UserStoreAPI.Models
{
    public class Like
    {
        public Guid LikerId { get; set; }
        public Guid LikeeId { get; set; }
        public DateTime DateLiked { get; set; }
        public User Liker { get; set; }
        public User Likee { get; set; }
    }
}