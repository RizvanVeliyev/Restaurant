using AutoMapper;
using Restaurant.BLL.Dtos.CategoryDetailDtos;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.AutoMapper
{
    internal class CategoryDetailAutoMapper : Profile
    {
        public CategoryDetailAutoMapper()
        {
            CreateMap<CategoryDetail, CategoryDetailCreateDto>().ReverseMap();
            CreateMap<CategoryDetail, CategoryDetailUpdateDto>().ReverseMap();
        }
    }
}
