using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.BlogCommentDtos
{
    public class BlogCommentCreateDto : IDto
    {
        public int BlogId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }

    }
}
