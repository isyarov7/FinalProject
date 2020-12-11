using System.Threading.Tasks;
using YVN.Services.DTOs;

namespace YVN.Services.Contracts
{
    public interface IFriendRequestService
    {
        Task<FriendRequestDTO> Create(FriendRequestDTO friendRequestDTO);
        Task<FriendRequestDTO> Accept(int senderId, int receiverId);
        Task<FriendRequestDTO> Delete(int senderId, int receiverId);
        Task<FriendRequestDTO> Decline(int senderId, int receiverId);
        Task<bool> Exists(int senderId, int receiverId);
        Task<FriendRequestDTO> GetFriendRequest(int id);
        Task<FriendRequestDTO> Update(FriendRequestDTO friendRequestDTO);


    }
}
