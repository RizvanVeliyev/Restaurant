using AutoMapper;
using Restaurant.BLL.Dtos.BlogCommentDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class BlogCommentAutoMapper : Profile
    {
        public BlogCommentAutoMapper()
        {
            CreateMap<BlogComment, BlogCommentCreateDto>().ReverseMap();
            CreateMap<BlogComment, BlogCommentUpdateDto>().ReverseMap();
            CreateMap<BlogComment, BlogCommentGetDto>().ReverseMap();
        }
    }
}
