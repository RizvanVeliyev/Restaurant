using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Blog:BaseEntity
    {

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Author { get; set; } = null!;
        public BlogCategory BlogCategory { get; set; } = null!;
        public int BlogCategoryId { get; set; }
        public string ImageUrl { get; set; } = null!; 
        public ICollection<BlogDetail> BlogDetails { get;set; } = [];
        public ICollection<Comment> Comments { get; set; } = [];

        //Burda her blogun yalniz bir esas sekli oldugu ucun blogimage table ehtiyac yoxdu, sadece blog ozunde string imageurl kifayetdi

    }
}
