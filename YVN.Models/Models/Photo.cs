using System.Collections.Generic;
using YVN.Models.Abstract;
using YVN.Models.Enums;

namespace YVN.Models.Models
{
    public class Photo : Entity
    {
        public int Id { get; set; }
        public byte[] PhotoAsBytes { get; set; }
        public bool IsProfilePicture { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public Visability Visability { get; set; }
        public int Likes { get; set; }

        // TODO remove this relation - Photo isnt "stand alone" as part of the post, photo have relation with comments.. 
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
