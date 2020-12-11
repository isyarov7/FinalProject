using System;
using System.Collections.Generic;
using System.Linq;
using YVN.Models.Models;
using YVN.Services.DTOs;

namespace YVN.Services.MappersDTO
{
    public static class FriendDTOMapper
    {
        public static FriendDTO GetDTO(this Friend item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new FriendDTO
            {
                Id = item.Id,
                FriendId = item.FriendId,
                IsDeleted = item.IsDeleted
            };
        }
        public static Friend GetFriend(this FriendDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new Friend
            {
                Id = item.Id,
                FriendId = item.FriendId,
                IsDeleted = item.IsDeleted
            };
        }

        public static ICollection<FriendDTO> GetDTO(this ICollection<Friend> items)
        {
            return items.Select(GetDTO).ToList();
        }
    }
}
