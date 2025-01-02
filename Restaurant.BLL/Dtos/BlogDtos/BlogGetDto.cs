using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.BlogDtos
{
    public class BlogGetDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        //public BlogCategoryGetDto Category { get; set; } = null!;

        public string ImagePath { get; set; } = null!;
        public List<string> ImagePaths { get; set; } = [];

        //comment niye saxlamirig?


    }
}
