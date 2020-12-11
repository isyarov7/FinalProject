using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using YVN.Services.Contracts;
using YVN.Services.DTOs;
using YVN.Web.Models;

namespace YVN.Web.Controllers
{
    [Authorize]
    public class FriendRequestController : Controller
    {
        private readonly IFriendRequestService _service;
        private readonly IMapper _mapper;

        public FriendRequestController(IFriendRequestService friendRequestService, IMapper mapper)
        {
            _service = friendRequestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequest(int id)
        {
            return Ok(await _service.GetFriendRequest(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(FriendRequestViewModel model)
        {

            var friendRequestDTO = _mapper.Map<FriendRequestDTO>(model);

            await _service.Create(friendRequestDTO);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateRequest(FriendRequestViewModel model)
        {
            var friendRequestDTO = _mapper.Map<FriendRequestDTO>(model);

            await _service.Update(friendRequestDTO);

            return RedirectToAction(nameof(Index));
        }
    }
}
