using System.ComponentModel.DataAnnotations;
using YVN.Models.Abstract;

namespace YVN.Models.Models
{
    public class Comment : Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(4000, MinimumLength = 1)]
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
