using Restaurant.BLL.Dtos.CategoryDtos;
using Restaurant.BLL.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.UI.Dtos
{
    public class MenuDto
    {
        public List<ProductGetDto> Products { get; set; } = new();
        public List<CategoryGetDto> Categories { get; set; } = new();
    }
}
