using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.CommonDtos
{
    public class ErrorDto : IDto
    {
        public string Name { get; set; } = "Xəta baş verdi";
        public string Message { get; set; } = null!;
        public int StatusCode { get; set; }
    }
}
