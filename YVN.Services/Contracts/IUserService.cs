using System.Collections.Generic;
using System.Threading.Tasks;
using YVN.Models.Models;
using YVN.Services.DTOs;

namespace YVN.Services.Contracts
{
    public interface IUserService
    {
        Task<string> GetUserName(int id);
        Task<int> GetUserId(string UserName);
        Task<User> GetUser(int id);
        Task<User> GetUser(string userName);
        Task<UserDTO> GetUserDTO(int id);
        Task<UserDTO> GetUserDTO(string userName);
        Task<ICollection<FriendDTO>> GetAllFriends(int id);
        Task<UserDTO> SetProfilePicture(int photoId, int userId);
        Task<bool> CheckIfFriends(int requestUserId, int targetUserId);

        // Task<bool> MakeFriends(int senderId, int receiverId);
        Task<UserDTO> EditUser(int id, string firstName, string lastName, int age, string username);
        Task<UserDTO> DeleteUser(int id);
        Task<bool> UserExists(int userId);
        Task<UserDTO> SearchUserByUsername(string username);

        // Task<bool> AddCommentToUser???
    }
}
