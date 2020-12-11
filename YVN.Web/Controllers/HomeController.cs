using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YNV___YourVirtualNeighborhood.Models;
using YVN.Services.Contracts;
using YVN.Web.Models;
using YVN.Web.Models.HomeViewModels;

namespace YNV___YourVirtualNeighborhood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IPostService postService, IPhotoService photoService, IMapper mapper, IUserService userService)
        {
            _logger = logger;
            _postService = postService;
            _photoService = photoService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var indexViewModel = new IndexViewModel();
            var publicPostsDTO = await _postService.GetAllPublicPost();
            var reversedPosts = publicPostsDTO.Reverse();

            var publicPostsVM = reversedPosts.Select(_mapper.Map<IndexPublicPostViewModel>).ToList();
            indexViewModel.PublicPosts = publicPostsVM;

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ReadInp(string data)
        {
            return this.Json(data);
        }

       [HttpPost]
       public async Task<IActionResult> SearchUser(string username)
       {
            var user = await _userService.SearchUserByUsername(username);
            var viewModel = new SearchViewModel() { FirstName = user.FirstName, LastName = user.LastName, Username = user.UserName };
            return View("SearchUser", viewModel);

       }
    }
}
