using System.Collections.Generic;
using System.Threading.Tasks;
using YVN.Services.DTOs;

namespace YVN.Services.Contracts
{
    public interface IPostService
    {
        Task<PostDTO> Create(PostDTO postDTO);

        Task<PostDTO> Edit(PostDTO postDTO);

        Task<PostDTO> GetAllLikes(int id);

        Task<bool> Delete(int postId);

        Task<bool> PostExsist(int id);

        Task<ICollection<PostDTO>> GetAllPostByUser(int userId);

        Task<ICollection<PostDTO>> GetAllPublicPost();

        Task<PostDTO> GetPost(int id);

        Task<bool> Like(int id);
    }
}
