using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using YVN.Services.DTOs;

namespace YVN.Services.Contracts
{
    public interface IPhotoService
    {
        Task<PhotoDTO> AddPhoto(PhotoDTO photoDTO);
        Task<PhotoDTO> EditVisability(PhotoDTO photoDTO);
        Task<PhotoDTO> DeletePhoto(int id);
        Task<PhotoDTO> GetAllLikes(int id);
        Task<byte[]> PhotoAsBytes(IFormFile photo);
        Task<PhotoDTO> GetPhoto(int id);
        Task<bool> Exists(int id);
    }
}
