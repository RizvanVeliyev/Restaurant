using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class BlogComment : BaseAuditableEntity
    {
        public string Text { get; set; } = null!;
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; } = null!;
        public int Rating { get; set; }
        public int? BlogId { get; set; }
        public Blog? Blog { get; set; } = null!;
    }
}
