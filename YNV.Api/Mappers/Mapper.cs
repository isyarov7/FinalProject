using AutoMapper;
using YNV.Api.Models;
using YVN.Services.DTOs;

namespace YNV.Api.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreatePostRequest, PostDTO>();
            CreateMap<PostDTO, PostResponse>();
        }
    }
}
