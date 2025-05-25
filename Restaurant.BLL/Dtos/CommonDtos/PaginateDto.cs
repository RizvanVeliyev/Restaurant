using Restaurant.BLL.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Dtos.CommonDtos
{
    public class PaginateDto<T> where T : class, IDto
    {
        public List<T> Items { get; set; } = [];
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
