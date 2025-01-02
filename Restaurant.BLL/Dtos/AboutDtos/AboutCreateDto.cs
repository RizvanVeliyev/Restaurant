using Microsoft.AspNetCore.Http;
using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.AboutDetailDtos;

namespace Restaurant.BLL.Dtos.AboutDtos
{
    public class AboutCreateDto : IDto
    {
        public IFormFile? Image { get; set; } = null!;
        public List<AboutDetailCreateDto> AboutDetails { get; set; } = new List<AboutDetailCreateDto>();

        //=[] c#9 da gelib yuxarida yazdginin eynisidi sadece syntax ferqi var.
    }
}
