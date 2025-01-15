using Restaurant.BLL.Dtos.BlogCommentDtos;
using Restaurant.BLL.Services.Abstractions.Generics;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface IBlogCommentService : IModifyService<BlogCommentCreateDto, BlogCommentUpdateDto>, IGetService<BlogCommentGetDto>
    {
        Task<List<BlogCommentGetDto>> GetBlogCommentsAsync(int blogId);
        Task<bool> CheckIsAllowBlogCommentAsync(int blogId);
    }
}
