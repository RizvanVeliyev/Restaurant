using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; } = null!;
        public bool IsSubscribed { get; set; } = false;
        public bool isDeleted { get; set; } = false;
    }
}
