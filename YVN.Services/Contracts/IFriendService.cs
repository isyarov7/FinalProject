using System.Threading.Tasks;
using YVN.Services.DTOs;

namespace YVN.Services.Contracts
{
    public interface IFriendService
    {
        Task<FriendDTO> AddFriend(FriendDTO friendDTO);
        Task<FriendDTO> RemoveFriend(int id);
    }
}
