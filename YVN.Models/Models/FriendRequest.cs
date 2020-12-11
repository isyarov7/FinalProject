using System.ComponentModel.DataAnnotations;
using YVN.Models.Enums;

namespace YVN.Models.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public User Sender { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        [Required]
        public FriendRequestStatus FriendRequestStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}
