using System;
using System.Collections.Generic;
using YVN.Models.Models;

namespace YNV.Api.Models.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public ICollection<Friend> Friends { get; set; } = new HashSet<Friend>();
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    }
}
