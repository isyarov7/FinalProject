using System.Collections.Generic;
using System.Threading.Tasks;
using YVN.Services.DTOs;

namespace YVN.Services.Contracts
{
    public interface ICommentService
    {
        Task<CommentDTO> CreateComment(CommentDTO commentDTO);
        Task<bool> DeleteComment(int id);
        Task<CommentDTO> EditComment(CommentDTO commentDTO);
        Task<CommentDTO> GetCommentById(int commentId);
        Task<ICollection<CommentDTO>> GetAllCommentByPost(int postId);
        CommentDTO GetComment(int id);
    }
}
