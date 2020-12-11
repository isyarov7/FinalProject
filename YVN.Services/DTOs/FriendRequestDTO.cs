using YVN.Models.Enums;

namespace YVN.Services.DTOs
{
    public class FriendRequestDTO
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public FriendRequestStatus FriendRequestStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}
