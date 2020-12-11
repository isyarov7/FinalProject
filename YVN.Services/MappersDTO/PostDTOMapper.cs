using System;
using System.Collections.Generic;
using System.Linq;
using YVN.Models.Models;
using YVN.Services.DTOs;

namespace YVN.Services.MappersDTO
{
    public static class PostDTOMapper
    {
        public static PostDTO GetDTO(this Post item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new PostDTO
            {
                Id = item.Id,
                Content = item.Content,
                Likes = item.Likes,
                UserId = item.UserId,
                User = item.User,
                PhotoId = item.PhotoId,
                Photo = item.Photo,
                Comments = item.Comments,
                IsDeleted = item.IsDeleted,
                CreatedOn = item.CreatedOn,
                EditedOn = item.EditedOn,
                DeletedOn = item.DeletedOn,
                Visability = item.Visability,
            };
        }

        public static Post GetPost(this PostDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new Post
            {
                Id = item.Id,
                Content = item.Content,
                Likes = item.Likes,
                UserId = item.UserId,
                User = item.User,
                PhotoId = item.PhotoId,
                Photo = item.Photo,
                Comments = item.Comments,
                IsDeleted = item.IsDeleted,
                CreatedOn = item.CreatedOn,
                EditedOn = item.EditedOn,
                DeletedOn = item.DeletedOn,
                Visability = item.Visability,
            };
        }

        public static ICollection<PostDTO> GetDTO(this ICollection<Post> items)
        {
            return items.Select(GetDTO).ToList();
        }
    }
}
