using Restaurant.BLL.Dtos.CommentDtos;
using Restaurant.BLL.Services.Abstractions.Generics;

namespace Restaurant.BLL.Services.Abstractions
{
    public interface ICommentService : IModifyService<CommentCreateDto, CommentUpdateDto>, IGetService<CommentGetDto>
    {
        Task<List<CommentGetDto>> GetProductCommentsAsync(int productId);
        Task<bool> CheckIsAllowCommentAsync(int productId);
    }
}
