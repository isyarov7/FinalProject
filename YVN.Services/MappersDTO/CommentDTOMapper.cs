using System;
using System.Collections.Generic;
using System.Linq;
using YVN.Models.Models;
using YVN.Services.DTOs;

namespace YVN.Services.MappersDTO
{
    public static class CommentDTOMapper
    {
        public static CommentDTO GetDTO(this Comment item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new CommentDTO
            {
                Id = item.Id,
                Content = item.Content,
                CreatedOn = item.CreatedOn,
                IsDeleted = item.IsDeleted,
                UserId = item.UserId,
                PostId = item.PostId,

            };
        }
        public static Comment GetComment(this CommentDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            return new Comment
            {
                Id = item.Id,
                Content = item.Content,
                CreatedOn = item.CreatedOn,
                IsDeleted = item.IsDeleted,
                UserId = item.UserId,
                PostId = item.PostId
            };
        }

        public static ICollection<CommentDTO> GetDTO(this ICollection<Comment> items)
        {
            return items.Select(GetDTO).ToList();
        }
    }
}
