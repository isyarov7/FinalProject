using YVN.Models.Enums;

namespace YVN.Web.Models
{
    public class FriendRequestViewModel
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public FriendRequestStatus FriendRequestStatus { get; set; }
    }
}
