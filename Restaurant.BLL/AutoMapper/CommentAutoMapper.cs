using AutoMapper;
using Restaurant.BLL.Dtos.CommentDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class CommentAutoMapper : Profile
    {
        public CommentAutoMapper()
        {
            CreateMap<Comment, CommentCreateDto>().ReverseMap();
            CreateMap<Comment, CommentUpdateDto>().ReverseMap();
            CreateMap<Comment, CommentGetDto>().ReverseMap();
            CreateMap<Comment, CommentReplyDto>().ReverseMap();
        }
    }
}
