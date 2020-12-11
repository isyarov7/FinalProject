using System;
using System.Collections.Generic;
using System.Linq;
using YVN.Models.Models;
using YVN.Services.DTOs;

namespace YVN.Services.MappersDTO
{
    public static class UserDTOMapper
    {
        public static UserDTO GetDTO(this User profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException();
            }
            return new UserDTO
            {
                Id = profile.Id,
                UserName = profile.UserName,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Age = profile.Age ?? 0,
                CreatedOn = profile.CreatedOn,
                EditedOn = profile.EditedOn,
                Friends = profile.Friends,
                Posts = profile.Posts,
                Photos = profile.Photos
            };
        }

        public static User GetUser(this UserDTO profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException();
            }
            return new User
            {
                Id = profile.Id,
                UserName = profile.UserName,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Age = profile.Age,
                CreatedOn = profile.CreatedOn,
                EditedOn = profile.EditedOn,
                Friends = profile.Friends,
                Posts = profile.Posts,
                Photos = profile.Photos
            };
        }

        public static ICollection<UserDTO> GetDTO(this ICollection<User> profiles)
        {
            return profiles.Select(GetDTO).ToList();
        }
    }
}
