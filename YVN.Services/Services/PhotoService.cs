using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YVN.Database;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Services.MappersDTO;
using static YVN.Services.Mesages.Constant_ExceptionMessages;

namespace YVN.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly YvnDbContext _context;

        public PhotoService(YvnDbContext context)
        {
            _context = context;
        }

        public async Task<PhotoDTO> AddPhoto(PhotoDTO photoDTO)
        {

            if (_context.Photos.Any(b => b.Id == photoDTO.Id))
            {
                var oldPhoto = _context.Photos.Where(b => b.Id == photoDTO.Id).FirstOrDefault();
                _context.Photos.Remove(oldPhoto);
            }

            _context.Photos.Add(photoDTO.GetPhoto());

            await _context.SaveChangesAsync();

            return photoDTO;
        }

        public async Task<PhotoDTO> DeletePhoto(int id)
        {
            var photo = await this._context.Photos
                .Include(x => x.Id)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            photo.IsDeleted = true;

            await _context.SaveChangesAsync();

            return photo.GetDTO();
        }

        public async Task<PhotoDTO> EditVisability(PhotoDTO photoDTO)
        {
            if (await this.Exists(photoDTO.Id))
            {
                var photo = _context.Photos
                    .FirstOrDefault(p => p.Id == photoDTO.Id);

                photo.Visability = photoDTO.Visability;
                await _context.SaveChangesAsync();
                return photo.GetDTO();
            }
            throw new Exception(PHOTO_NULL);
        }

        public async Task<bool> Exists(int id)
        {
            var photo = await _context
               .Photos
               .AnyAsync(p => p.Id == id && p.IsDeleted == false);

            return photo;
        }

        public async Task<PhotoDTO> GetAllLikes(int id)
        {
            var photo = await this._context.Photos
                .Include(r => r.Likes)
                .FirstOrDefaultAsync(r => r.Id == id);

            return photo.GetDTO();
        }

        public async Task<PhotoDTO> GetPhoto(int id)
        {
            var photo = await this._context.Photos
            .FirstOrDefaultAsync(photo => photo.Id == id);

            return photo.GetDTO();
        }

        public async Task<byte[]> PhotoAsBytes(IFormFile photo)
        {
            byte[] photoAsBytes;

            await using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                photoAsBytes = memoryStream.ToArray();
            };

            return photoAsBytes;
        }
    }
}
