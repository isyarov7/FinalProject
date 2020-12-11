using System;
using System.ComponentModel.DataAnnotations;

namespace YVN.Web.Models.CommentViewModel
{
    public class CommentViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Comment:")]
        public string Content { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Photo { get; set; }

        public string UserProfilePicture { get; set; }

        public string UserFullName { get; set; }
    }
}
