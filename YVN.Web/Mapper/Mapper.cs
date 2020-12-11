using AutoMapper;
using YVN.Models.Models;
using YVN.Services.DTOs;
using YVN.Web.Models;
using YVN.Web.Models.CommentViewModel;
using YVN.Web.Models.HomeViewModels;
using YVN.Web.Models.PostViewModel;

namespace YVN.Web.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<FriendDTO, FriendViewModel>().ReverseMap();
            CreateMap<FriendRequestDTO, FriendRequestViewModel>().ReverseMap();
            CreateMap<CommentDTO, CommentViewModel>().ReverseMap();
            CreateMap<PostDTO, PostViewModel>().ReverseMap();
            CreateMap<PhotoDTO, PhotoViewModel>().ReverseMap();
            CreateMap<PostDTO, IndexPublicPostViewModel>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<PostDTO, CreatePostViewModel>().ReverseMap();

        }
    }
}
