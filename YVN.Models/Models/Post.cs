using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YVN.Models.Abstract;

namespace YVN.Models.Models
{
    public class Post : Entity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(4000)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public int UserId { get; set; }

        public User User { get; set; }

        public int? PhotoId { get; set; }

        public Photo Photo { get; set; }

        public string Visability { get; set; }
    }
}
