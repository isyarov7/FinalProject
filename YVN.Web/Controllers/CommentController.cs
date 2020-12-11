using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YVN.Models.Models;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Web.Models.CommentViewModel;

namespace YVN.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, SignInManager<User> signInManager, IMapper mapper)
        {
            _commentService = commentService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                Response.Redirect("https://localhost:44306/Identity/Account/Login");
            }
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CommentViewModel comment)
        {

            var commentDTO = _mapper.Map<CommentDTO>(comment);

            await _commentService.CreateComment(commentDTO);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(CommentDTO commentDTO)
        {

            if (!_signInManager.IsSignedIn(User))
            {
                Response.Redirect("https://localhost:44306/Identity/Account/Login");
            }
            var comment = _commentService.EditComment(commentDTO);

            ViewData["Content"] = _commentService.EditComment(commentDTO);

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CommentViewModel commentViewModel)
        {
            var commentDTO = _mapper.Map<CommentDTO>(commentViewModel);

            await _commentService.EditComment(commentDTO);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                Response.Redirect("https://localhost:44306/Identity/Account/Login");
            }
            var comment = _commentService.GetComment(id);

            return View(comment);
        }
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _commentService.DeleteComment(id);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
