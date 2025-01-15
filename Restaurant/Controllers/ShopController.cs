﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.CommentDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Dtos;
using Restaurant.Core.Enums;
using Restaurant.Extensions;

namespace Restaurant.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public ShopController(IProductService productService, ICategoryService categoryService, ICommentService commentService, ILanguageService languageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _commentService = commentService;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync(_language);
            var categories=await _categoryService.GetAllAsync(_language);
            var shopDto = new ShopDto
            {
                Products = products,
                Categories = categories
            };

            return View(shopDto);
        }


        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetAsync(id, _language);
            var comments = await _commentService.GetProductCommentsAsync(id);
            var isAllowComment = await _commentService.CheckIsAllowCommentAsync(id);

            ShopDetailDto dto = new()
            {
                Product = product,
                Comments = comments,
                IsAllowComment = isAllowComment
            };

            return View(dto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreateDto dto)
        {
            var result = await _commentService.CreateAsync(dto, ModelState);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteAsync(id);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }
    }
}
