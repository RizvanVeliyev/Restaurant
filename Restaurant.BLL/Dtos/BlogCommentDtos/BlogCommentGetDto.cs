using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.AppUserDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.Dtos.BlogCommentDtos
{
    public class BlogCommentGetDto : IDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }
        public UserGetDto AppUser { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<BlogComment> Children { get; set; } = [];

    }
}
