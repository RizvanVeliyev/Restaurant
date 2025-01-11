using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.ProductDtos;

namespace Restaurant.BLL.Dtos.ReservationDtos
{
    public class ReservationCreateDto
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Date { get; set; } 
        public string Time { get; set; } = null!;
        public ICollection<ProductGetDto> Products { get; set; } = [];
        public int NumberOfPeople { get; set; }
    }

}
