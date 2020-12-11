using System;
using System.Collections.Generic;
using System.Linq;
using YVN.Models.Models;
using YVN.Services.DTOs;

namespace YVN.Services.MappersDTO
{
    public static class PhotoDTOMapper
    {
        public static PhotoDTO GetDTO(this Photo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new PhotoDTO
            {
                PhotoAsBytes = item.PhotoAsBytes,
                IsProfilePicture = item.IsProfilePicture,
                UserId = item.UserId,
                Visability = item.Visability,
                PostId = item.PostId,
                Likes = item.Likes,
                Comments = item.Comments
            };
        }
        public static Photo GetPhoto(this PhotoDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new Photo
            {
                Id = item.Id,
                PhotoAsBytes = item.PhotoAsBytes,
                IsProfilePicture = item.IsProfilePicture,
                UserId = item.UserId,
                Visability = item.Visability,
                PostId = item.PostId,
                Likes = item.Likes,
                Comments = item.Comments
            };
        }

        public static ICollection<PhotoDTO> GetDTO(this ICollection<Photo> items)
        {
            return items.Select(GetDTO).ToList();
        }
    }
}
