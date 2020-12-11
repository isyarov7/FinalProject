using System;
using System.Collections.Generic;
using YVN.Models.Models;

namespace YNV.Api.Models
{
    public class PostResponse
    {
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public int Likes { get; set; }
    }
}
