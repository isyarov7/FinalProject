using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using YVN.Database;
using YVN.Models.Enums;
using YVN.Models.Models;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Services.MappersDTO;
using static YVN.Services.Mesages.Constant_ExceptionMessages;

namespace YVN.Services.Services
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly YvnDbContext _context;

        public FriendRequestService(YvnDbContext context)
        {
            _context = context;
        }

        public async Task<FriendRequestDTO> Accept(int senderId, int receiverId)
        {
            if (await this.Exists(senderId, receiverId))
            {
                var friendRequest = _context.FriendRequests
                    .FirstOrDefault(fr => fr.ReceiverId == receiverId && fr.SenderId == senderId);
                friendRequest.FriendRequestStatus = FriendRequestStatus.Accepted;
                var friend = new Friend
                {
                    userId = senderId,
                    FriendId = receiverId
                };
                _context.Friends.Add(friend);
                friendRequest.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            throw new Exception(GENERAL_ERROR);
        }

        public async Task<FriendRequestDTO> Create(FriendRequestDTO friendRequestDTO)
        {
            if (_context.FriendRequests.Any(b => b.Id == friendRequestDTO.Id))
            {
                throw new Exception(FRIEND_REQUEST_ALREADY_EXISTS);
            }

            _context.FriendRequests.Add(friendRequestDTO.GetFriendRequest());

            await _context.SaveChangesAsync();

            return friendRequestDTO;
        }

        public async Task<FriendRequestDTO> Decline(int senderId, int receiverId)
        {
            if (await this.Exists(senderId, receiverId))
            {
                var friendRequest = _context.FriendRequests
                    .FirstOrDefault(fr => fr.ReceiverId == receiverId && fr.SenderId == senderId);

                if (friendRequest.FriendRequestStatus == FriendRequestStatus.Pending)
                {
                    friendRequest.FriendRequestStatus = FriendRequestStatus.Declined;
                    friendRequest.IsDeleted = true;
                    await _context.SaveChangesAsync();
                    return friendRequest.GetDTO();
                }
            }

            throw new Exception(FRIEND_REQUEST_DOESNT_EXISTS);
        }

        public async Task<FriendRequestDTO> Delete(int senderId, int receiverId)
        {
            var friendRequest = await _context.FriendRequests
                .FirstOrDefaultAsync(x => x.SenderId == senderId && x.ReceiverId == receiverId && x.IsDeleted == false);

            friendRequest.IsDeleted = true;

            await _context.SaveChangesAsync();

            return friendRequest.GetDTO();
        }

        public async Task<bool> Exists(int senderId, int receiverId)
        {
            var friendRequest = await _context
                .FriendRequests
                .AnyAsync(fr => fr.SenderId == senderId && fr.ReceiverId == receiverId && fr.IsDeleted == false);

            return friendRequest;
        }

        public async Task<FriendRequestDTO> GetFriendRequest(int id)
        {
            var request = await this._context.FriendRequests
           .FirstOrDefaultAsync(request => request.Id == id);

            return request.GetDTO();
        }

        public async Task<FriendRequestDTO> Update(FriendRequestDTO friendRequestDTO)
        {
            if (await this.Exists(friendRequestDTO.SenderId, friendRequestDTO.ReceiverId))
            {
                var friendRequest = _context.FriendRequests
                    .FirstOrDefault(fr => fr.ReceiverId == friendRequestDTO.ReceiverId
                    && fr.SenderId == friendRequestDTO.SenderId);

                friendRequest.FriendRequestStatus = friendRequestDTO.FriendRequestStatus;
                await _context.SaveChangesAsync();
                return friendRequest.GetDTO();
            }
            throw new Exception(USER_NULL);
        }
    }
}
