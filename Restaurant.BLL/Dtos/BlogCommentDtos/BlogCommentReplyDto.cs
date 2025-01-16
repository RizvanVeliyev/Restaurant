using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.BlogCommentDtos
{
    public class BlogCommentReplyDto : IDto
    {
        public int ParentId { get; set; }
        public int ProductId { get; set; }

        public string Text { get; set; } = null!;
    }
}
