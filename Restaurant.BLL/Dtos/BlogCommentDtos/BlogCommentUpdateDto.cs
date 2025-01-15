using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.BlogCommentDtos
{
    public class BlogCommentUpdateDto : IDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }
    }
}
