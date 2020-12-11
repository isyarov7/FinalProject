using System.Collections.Generic;
using YVN.Models.Models;

namespace YVN.Web.Models
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public byte[] PhotoAsBytes { get; set; }
        public bool IsProfilePicture { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool IsDeleted { get; set; }
        public int Likes { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
