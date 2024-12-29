using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class About : BaseEntity
    {
        public string ImagePath { get; set; } = null!;
        public ICollection<AboutDetail> AboutDetails { get; set; } = [];
    }
}
