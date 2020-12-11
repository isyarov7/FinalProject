using System;
using System.Collections.Generic;
using System.Linq;
using YVN.Models.Models;
using YVN.Services.DTOs;

namespace YVN.Services.MappersDTO
{
    public static class FriendRequestDTOMapper
    {
        public static FriendRequestDTO GetDTO(this FriendRequest item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new FriendRequestDTO
            {
                Id = item.Id,
                ReceiverId = item.ReceiverId,
                SenderId = item.SenderId,
                FriendRequestStatus = item.FriendRequestStatus,
                IsDeleted = item.IsDeleted
            };
        }
        public static FriendRequest GetFriendRequest(this FriendRequestDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new FriendRequest
            {
                Id = item.Id,
                ReceiverId = item.ReceiverId,
                SenderId = item.SenderId,
                FriendRequestStatus = item.FriendRequestStatus,
                IsDeleted = item.IsDeleted
            };
        }

        public static ICollection<FriendRequestDTO> GetDTO(this ICollection<FriendRequest> items)
        {
            return items.Select(GetDTO).ToList();
        }
    }
}
