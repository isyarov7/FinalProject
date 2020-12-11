using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YVN.Services.Contracts;

namespace YNV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserApiController(IUserService userService, IMapper mapper)
        {
            _service = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetInfo")]
        public async Task<IActionResult> GetInfo(int userId)
        {
            return Ok(await _service.GetUserDTO(userId));
        }

        [HttpGet]
        [Route("GetFriends")]
        public async Task<IActionResult> GetFriends(int userId)
        {
            return Ok(await _service.GetAllFriends(userId));
        }
    }
}
