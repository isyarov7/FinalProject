using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using YVN.Database;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Services.MappersDTO;
using static YVN.Services.Mesages.Constant_ExceptionMessages;

namespace YVN.Services.Services
{
    public class FriendService : IFriendService
    {
        private readonly YvnDbContext _context;

        public FriendService(YvnDbContext context)
        {
            _context = context;
        }

        public async Task<FriendDTO> AddFriend(FriendDTO friendDTO)
        {
            if (_context.Friends.Any(b => b.Id == friendDTO.Id))
            {
                throw new Exception(USER_ALREADY_IN_FRIENDLIST);
            }

            _context.Friends.Add(friendDTO.GetFriend());

            await _context.SaveChangesAsync();

            return friendDTO;
        }

        public async Task<FriendDTO> RemoveFriend(int id)
        {
            var friend = await this._context.Friends
                 .Include(x => x.Id)
                 .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            friend.IsDeleted = true;

            await _context.SaveChangesAsync();

            return friend.GetDTO();
        }
    }
}
