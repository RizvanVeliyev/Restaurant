using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CommentDtos
{
    public class CommentCreateDto:IDto
    {
        //public int BlogId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; } = null!;
        public int Rating { get; set; }

    }
    
}
