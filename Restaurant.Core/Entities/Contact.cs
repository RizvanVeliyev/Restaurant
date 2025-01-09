using Restaurant.Core.Entities.Commons;

namespace Restaurant.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Message { get; set; } = null!;

    }
}
