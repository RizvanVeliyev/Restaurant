using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogCommentDtos;
using Restaurant.BLL.Dtos.BlogDtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class BlogDetailDto : IDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public BlogGetDto Blog { get; set; } = null!;
        public List<BlogCommentGetDto> BlogComments { get; set; } = [];
        public bool IsAllowBlogComment { get; set; } = false;
        public int? NextBlogId { get; set; } // Növbəti Blog ID
        public int? PrevBlogId { get; set; } // Əvvəlki Blog ID
    }
}
