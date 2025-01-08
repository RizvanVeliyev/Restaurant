﻿using AutoMapper;
using Restaurant.BLL.Dtos.BlogDtos;
using Restaurant.BLL.Dtos.ProductDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class ProductAutoMapper : Profile
    {
        public ProductAutoMapper()
        {
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>()
                .ForMember(x => x.MainImagePath, x => x.MapFrom(x => x.ProductImages.FirstOrDefault(x => x.IsMain) != null ? x.ProductImages.FirstOrDefault(x => x.IsMain)!.Path : string.Empty))
                .ForMember(x => x.ImagePaths, x => x.MapFrom(x => x.ProductImages.Where(x => !x.IsMain).Select(x => x.Path)))
                .ForMember(x => x.ImageIds, x => x.MapFrom(x => x.ProductImages.Where(x => !x.IsMain).Select(x => x.Id)))
                .ReverseMap();

            CreateMap<Product, ProductGetDto>()
                           .ForMember(x => x.Name, x => x.MapFrom(src => src.ProductDetails.FirstOrDefault() != null ? src.ProductDetails.FirstOrDefault()!.Name : string.Empty))
                           .ForMember(x => x.Description, x => x.MapFrom(src => src.ProductDetails.FirstOrDefault() != null ? src.ProductDetails.FirstOrDefault()!.Description : string.Empty))
                           .ForMember(x => x.MainImagePath, x => x.MapFrom(src => src.ProductImages.FirstOrDefault(img => img.IsMain) != null ? src.ProductImages.FirstOrDefault(img => img.IsMain)!.Path : string.Empty))
                           .ForMember(x => x.ImagePaths, x => x.MapFrom(src => src.ProductImages.Where(x => !x.IsMain).Select(x => x.Path)));




        }
    }

   
}
