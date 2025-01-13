using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.Services.Implementations;
using Restaurant.BLL.UI.Dtos;
using Restaurant.Core.Enums;

namespace Restaurant.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly ICommentService _commentService;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public BlogController(IBlogService blogService, IBlogCategoryService blogCategoryService, ICommentService commentService, ILanguageService languageService)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
            _commentService = commentService;
            _languageService = languageService;
            _language = _languageService.RenderSelectedLanguage();
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync(_language);
            var blogCategories = await _blogCategoryService.GetAllAsync(_language);
            var blogDto = new BlogDto
            {
                Blogs= blogs,
                BlogCategories = blogCategories
            };

            return View(blogDto);
        }

        public async Task<IActionResult> Detail(string? slug, int id)
        {
            var blog = await _blogService.GetAsync(id, _language);
            var comments = await _commentService.GetProductCommentsAsync(id);
            var isAllowComment = await _commentService.CheckIsAllowCommentAsync(id);

            BlogDetailDto dto = new()
            {
                Blog = blog,
                Comments = comments,
                IsAllowComment = isAllowComment
            };

            return View(dto);
        }


    }
}
