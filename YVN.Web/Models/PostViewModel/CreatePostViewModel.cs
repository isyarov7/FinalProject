using System.Collections.Generic;

namespace YVN.Web.Models.PostViewModel
{
    public class CreatePostViewModel
    {
        public CreatePostViewModel()
        {

        }

        public string Content { get; set; }

        public string Visability { get; set; }

        public int UserId { get; set; }

        public List<string> VisabilityValues { get; set; }
    }
}
