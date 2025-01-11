using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.UI.Dtos
{
    public class ContactDto:IDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
