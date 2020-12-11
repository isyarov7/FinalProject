using YVN.Models.Abstract;

namespace YVN.Models.Models
{
    public class Friend : Entity
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public User FriendOfUser { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}
