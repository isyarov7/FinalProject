using System;

namespace YVN.Services.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public byte[] UserProfilePicture { get; set; }
        public string UserFullName { get; set; }
    }
}
