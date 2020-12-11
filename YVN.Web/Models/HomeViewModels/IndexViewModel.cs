using System.Collections.Generic;

namespace YVN.Web.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<IndexPublicPostViewModel> PublicPosts { get; set; }
    }
}
