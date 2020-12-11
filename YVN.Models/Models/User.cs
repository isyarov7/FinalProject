using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YVN.Models.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public override string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        [Range(0, 180)]
        public int? Age { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Nationality { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime EditedOn { get; set; }

        public ICollection<Friend> Friends { get; set; } = new HashSet<Friend>();
        public ICollection<Friend> FriendsOf { get; set; } = new HashSet<Friend>();

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();

        public ICollection<FriendRequest> FriendRequestSent { get; set; } = new HashSet<FriendRequest>();

        public ICollection<FriendRequest> FriendRequestReceived { get; set; } = new HashSet<FriendRequest>();

        public bool IsDeleted { get; set; }
    }
}
