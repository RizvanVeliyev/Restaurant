using AutoMapper;
using Restaurant.BLL.Dtos.IngredientDtos;
using Restaurant.Core.Entities;

namespace Restaurant.BLL.AutoMapper
{
    internal class IngredientAutoMapper : Profile
    {
        public IngredientAutoMapper() 
        {
            CreateMap<Ingredient, IngredientGetDto>()
                               .ForMember(x => x.Name, x => x.MapFrom(x => x.IngredientDetails.FirstOrDefault() != null ? x.IngredientDetails.FirstOrDefault()!.Name : string.Empty));

        }

    }
}
