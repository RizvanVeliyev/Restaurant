using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.BLL.Dtos.CommentDtos;
using Restaurant.BLL.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.UI.Dtos
{
    public class BlogDetailDto : IDto
    {
        public BlogGetDto Blog { get; set; } = null!;
        public List<CommentGetDto> Comments { get; set; } = [];
        public bool IsAllowComment { get; set; } = false;
    }
}
