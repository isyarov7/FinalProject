using System;
using System.Collections.Generic;
using YVN.Models.Models;

namespace YVN.Web.Models.HomeViewModels
{
    public class IndexPublicPostViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public User User { get; set; }

        public Photo Photo { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime EditedOn { get; set; }

        // TODO edit URL
        //  public string Url => $"/p/{this.PostedOn.ToLongDateString()}"
    }
}