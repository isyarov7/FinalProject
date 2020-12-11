using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YVN.Models.Models;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Web.Models.PostViewModel;

namespace YVN.Web.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _usermanager;

        public PostsController(IPostService postService, IMapper mapper, SignInManager<User> signInManager, UserManager<User> usermanager)
        {
            _postService = postService;
            _mapper = mapper;
            _signInManager = signInManager;
            _usermanager = usermanager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int userId)
        {
            var userPostsDTO = await _postService.GetAllPostByUser(userId);
            var userPostsVM = userPostsDTO.Select(_mapper.Map<PostViewModel>).ToList();

            return View(userPostsVM);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var post = _postService.GetPost(id);
            return View(post);
        }

        // GET: Post/Create
        [HttpGet]
        public IActionResult Create()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                Response.Redirect("https://localhost:44306/Identity/Account/Login");
            }

            var createView = new CreatePostViewModel
            {
                VisabilityValues = new List<string> { "Private", "FriendsOnly", "Public" }
            };

            return View(createView);
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content", "Visability")] CreatePostViewModel inputPost)
        {
            if (ModelState.IsValid)
            {
                var userId = _usermanager.GetUserId(HttpContext.User);
                inputPost.UserId = int.Parse(userId);

                var postDTO = _mapper.Map<PostDTO>(inputPost);
                await _postService.Create(postDTO);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public IActionResult Edit(PostDTO postDTO)
        {

            if (!_signInManager.IsSignedIn(User))
            {
                Response.Redirect("https://localhost:44306/Identity/Account/Login");
            }
            var post = _postService.Edit(postDTO);

            ViewData["Content"] = _postService.Edit(postDTO);

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int postId, PostViewModel postViewModel)
        {
            var postDTO = _mapper.Map<PostDTO>(postViewModel);

            await _postService.Edit(postDTO);

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                Response.Redirect("https://localhost:44306/Identity/Account/Login");
            }

            var post = _postService.GetPost(id);

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _postService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Like(int postId)
        {
            if (await _postService.PostExsist(postId))
            {
                return this.NotFound();
            }

            await _postService.Like(postId);

            return RedirectToAction("Index", "Users");
        }
    }
}
