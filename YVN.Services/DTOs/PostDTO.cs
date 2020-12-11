using System;
using System.Collections.Generic;
using YVN.Models.Models;

namespace YVN.Services.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int? PhotoId { get; set; }

        public Photo Photo { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime EditedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Visability { get; set; }
    }
}
