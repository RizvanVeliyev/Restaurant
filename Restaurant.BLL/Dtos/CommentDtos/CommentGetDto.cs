using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.AppUserDtos;

namespace Restaurant.BLL.Dtos.CommentDtos
{
    public class CommentGetDto:IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        //public int BlogId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }
        public UserGetDto AppUser { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
