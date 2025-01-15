using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogCommentDtos;
using Restaurant.BLL.Dtos.BlogDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class BlogDetailDto : IDto
    {
        public BlogGetDto Blog { get; set; } = null!;
        public List<BlogCommentGetDto> BlogComments { get; set; } = [];
        public bool IsAllowBlogComment { get; set; } = false;
    }
}
