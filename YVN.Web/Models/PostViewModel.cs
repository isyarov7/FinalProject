using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YVN.Models.Models;

namespace YVN.Web.Models.PostViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "What do you think?")]
        public string Content { get; set; }

        public int Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public DateTime PostedOn { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int? PhotoId { get; set; }

        public Photo Photo { get; set; }

        public string Visability { get; set; }
    }
}
