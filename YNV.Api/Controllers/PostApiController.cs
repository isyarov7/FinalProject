using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YNV.Api.Models;
using YVN.Services.Contracts;
using YVN.Services.DTOs;

namespace YNV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostApiController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllPublicPosts")]
        public async Task<IActionResult> GetAllPublicPosts ()
        {
            return Ok(await _postService.GetAllPublicPost());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreatePostRequest request)
        {

            var postDTO = _mapper.Map<PostDTO>(request);

            var createdPost = await _postService.Create(postDTO);

            return Ok(_mapper.Map<PostResponse>(createdPost));
        }
    }
}
