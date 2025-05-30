﻿using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Dtos;
using Restaurant.BLL.UI.Services.Abstractions;
using Restaurant.Core.Enums;

namespace Restaurant.BLL.UI.Services.Implementations
{
    public class HomeService : IHomeService
    {
        
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IAboutService _aboutService;
        private readonly ICommentService _commentService;
        public HomeService(ICategoryService categoryService, IProductService productService, IAboutService aboutService, ICommentService commentService)
        {

            _categoryService = categoryService;
            _productService = productService;
            _aboutService = aboutService;
            _commentService = commentService;
        }

        public async Task<HomeDto> GetHomeDtoAsync(Languages language = Languages.Azerbaijan,int ? categoryId = null)
        {
            var categories = await _categoryService.GetAllAsync(language);
            var products = await _productService.GetAllAsync(language);
            var comments = await _commentService.GetAllAsync(7);
            var about = (await _aboutService.GetAllAsync(language)).FirstOrDefault();


            if (categoryId.HasValue && categoryId > 0)
            {
                products = products.Where(b => b.CategoryId == categoryId.Value).ToList();
            }

            HomeDto dto = new HomeDto()
            {
                Products = products,
                Categories=categories,
                About = about,
                Comments = comments
            };

            return dto;
        }
    }
}
