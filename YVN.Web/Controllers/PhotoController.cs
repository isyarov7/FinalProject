using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YVN.Services.Contracts;
using YVN.Services.DTOs;

namespace YVN.Web.Controllers
{
    [Authorize]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _service;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoService photoService, IMapper mapper)
        {
            _service = photoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoto(int id)
        {
            return Ok(await _service.GetPhoto(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(PhotoDTO photoDTO)
        {

            var requestDTO = _mapper.Map<PhotoDTO>(photoDTO);

            var addedRequest = await _service.AddPhoto(requestDTO);

            return Ok(_mapper.Map<PhotoDTO>(addedRequest));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            await _service.DeletePhoto(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePhoto(PhotoDTO photoDTO)
        {
            var photo = _mapper.Map<PhotoDTO>(photoDTO);

            var editedPhoto = await _service.EditVisability(photoDTO);

            return Ok(_mapper.Map<PhotoDTO>(editedPhoto));
        }
    }
}
