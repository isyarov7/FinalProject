using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YVN.Database;
using YVN.Models.Models;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Services.MappersDTO;
using static YVN.Services.Mesages.Constant_ExceptionMessages;

namespace YVN.Services.Services
{
    public class UserService : IUserService
    {
        private readonly YvnDbContext _context;

        public UserService(YvnDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string> GetUserName(int id)
        {
            var user = await _context
                .Users
                .Where
                (
                    u => u.Id == id
                    && !u.IsDeleted
                )
                .Select(u => new
                {
                    u.UserName
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            return user.UserName;
        }

        public async Task<int> GetUserId(string userName)
        {
            if (userName == null)
            {
                throw new Exception(GENERAL_ERROR);
            }

            var user = await _context
                .Users
                .Where
                (
                   u => u.UserName == userName
                   && !u.IsDeleted
                )
                .Select(u => new
                {
                    u.Id
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            return user.Id;
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _context
                .Users
                .FirstOrDefaultAsync
                 (
                    u => u.Id == id
                    && !u.IsDeleted
                 );

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            return user;
        }

        public async Task<User> GetUser(string userName)
        {
            if (userName == null)
            {
                throw new Exception(GENERAL_ERROR);
            }

            User user = await _context
                .Users
                .FirstOrDefaultAsync
                (
                  u => u.UserName == userName
                  && !u.IsDeleted
                );

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            return user;
        }

        public async Task<UserDTO> GetUserDTO(int id)
        {
            User user = await GetUser(id);
            if (user == null)
            {
                throw new Exception(USER_NULL);
            }
            return user.GetDTO();
        }

        public async Task<UserDTO> GetUserDTO(string userName)
        {
            User user = await GetUser(userName);
            if (user == null)
            {
                throw new Exception(USER_NULL);
            }
            return user.GetDTO();
        }

        public async Task<ICollection<FriendDTO>> GetAllFriends(int id)
        {
            var user = await _context
               .Users
               .Where(u => u.Id == id && !u.IsDeleted)
               .Select(u => new
               {
                   u.Friends,
               })
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            if (user.Friends == null)
            {
                throw new Exception(FRIENDSLIST_NULL);
            }

            var friends = user.Friends;
            return friends.GetDTO();
        }

        public async Task<UserDTO> SetProfilePicture(int photoId, int id)
        {
            var user = await _context
                                  .Users
                                  .Where(
                                   u => u.Id == id
                                   && !u.IsDeleted)
                                  .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            Photo profilePicture = user.Photos.Where
                           (
                               p => p.Id == photoId
                               && !p.IsDeleted
                           )
                           .FirstOrDefault();

            if (profilePicture == null)
            {
                throw new Exception(PHOTO_NULL);
            }

            profilePicture.IsProfilePicture = true;

            await _context.SaveChangesAsync();
            return user.GetDTO();
        }

        public async Task<bool> CheckIfFriends(int requestUserId, int targetUserId)
        {
            var areFriends = await _context
                .Friends
                .AnyAsync(uf =>
                (uf.FriendId == requestUserId && uf.FriendId == targetUserId)
                || (uf.FriendId == targetUserId && uf.FriendId == requestUserId));

            return areFriends;
        }

        public async Task<UserDTO> EditUser(int id, string firstName, string lastName, int age, string username)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            if (username != null && user.UserName != username)
            {
                user.UserName = username;
            }

            if (firstName != null && user.FirstName != null)
            {
                user.FirstName = firstName;
            }

            if (lastName != null && user.LastName != lastName)
            {
                user.LastName = lastName;
            }

            if (user.Age != age)
            {
                user.Age = age;
            }

            user.EditedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return user.GetDTO();
        }

        public async Task<UserDTO> DeleteUser(int id)
        {
            var user = await _context.Users
                                .Where(u => u.Id == id && !u.IsDeleted)
                                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception(USER_NULL);
            }

            user.IsDeleted = true;
            await _context.SaveChangesAsync();

            return user.GetDTO();
        }

        public async Task<bool> UserExists(int id)
        {
            var userExsist = await _context
                .Users
                .AnyAsync(u => u.Id == id && u.IsDeleted == false);

            return userExsist;
        }

        public async Task<UserDTO> SearchUserByUsername(string username)
        {
            var user = await _context.Users
                .Where(u => u.UserName.ToLower().Contains(username.ToLower()) && !u.IsDeleted)
                .FirstOrDefaultAsync();

            return user.GetDTO();
        }
    }
}
