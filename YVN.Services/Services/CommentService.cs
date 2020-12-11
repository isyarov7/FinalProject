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
    public class CommentService : ICommentService
    {
        private readonly YvnDbContext _context;

        public CommentService(YvnDbContext context)
        {
            _context = context;
        }

        public async Task<CommentDTO> CreateComment(CommentDTO commentDTO)
        {
            if (commentDTO.Content == null)
            {
                throw new Exception(COMMENT_NULL);
            }
            else if (commentDTO.Content.Length >= 4000)
            {
                throw new Exception(COMMENT_TOO_LONG);
            }

            var comment = new Comment
            {
                Content = commentDTO.Content,
                UserId = commentDTO.UserId,
                PostId = commentDTO.PostId
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment.GetDTO();
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var comment = await _context.Comments.Where(c => c.Id == commentId && !c.IsDeleted).FirstOrDefaultAsync();

            if (comment == null)
            {
                throw new Exception(COMMENT_NULL);
            }

            comment.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CommentDTO> EditComment(CommentDTO commentDTO)
        {
            var commentToEdit = await _context.Comments.Where(c => c.Id == commentDTO.Id && !c.IsDeleted).FirstOrDefaultAsync();

            if (commentToEdit == null)
            {
                throw new Exception(COMMENT_NULL);
            }

            var newComment = commentToEdit.Content;
            commentToEdit.EditedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return commentToEdit.GetDTO();
        }

        public async Task<CommentDTO> GetCommentById(int commentId)
        {
            var comment = await _context.Comments.Where(c => c.Id == commentId && !c.IsDeleted).FirstOrDefaultAsync();

            if (comment == null)
            {
                throw new Exception(COMMENT_NULL);
            }
            return comment.GetDTO();
        }

        public async Task<ICollection<CommentDTO>> GetAllCommentByPost(int postId)
        {
            var comments = await _context.Comments.Where(c => c.PostId == postId && !c.IsDeleted).ToListAsync();
            if (comments == null)
            {
                throw new Exception(COMMENT_NULL);
            }
            return comments.GetDTO();
        }
        public CommentDTO GetComment(int id)
        {
            var comment = this._context.Comments
            .Include(p => p.Content)
            .FirstOrDefault(post => post.Id == id);

            return comment.GetDTO();
        }
    }
}
