using YVN.Models.Models;

namespace YVN.Web.Models
{
    public class FriendViewModel
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public bool IsDeleted { get; set; }

        public string UserName { get; set; }
        public Photo ProfilePhoto { get; set; }
    }
}
