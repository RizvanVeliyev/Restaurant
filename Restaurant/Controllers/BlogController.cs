using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.BlogCommentDtos;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.UI.Dtos;
using Restaurant.Core.Enums;
using Restaurant.Extensions;

namespace Restaurant.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IBlogCommentService _commentService;
        private readonly ILanguageService _languageService;
        private readonly Languages _language;

        public BlogController(IBlogService blogService, IBlogCategoryService blogCategoryService, IBlogCommentService commentService, ILanguageService languageService)
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

        public async Task<IActionResult> Details(string? slug, int id)
        {
            var blog = await _blogService.GetAsync(id, _language);
            var comments = await _commentService.GetBlogCommentsAsync(id);
            var isAllowBlogComment = await _commentService.CheckIsAllowBlogCommentAsync(id);

            BlogDetailDto dto = new()
            {
                Blog = blog,
                BlogComments = comments,
                IsAllowBlogComment = isAllowBlogComment
            };

            return View(dto);
        }



        [HttpPost]
        public async Task<IActionResult> CreateBlogComment(BlogCommentCreateDto dto)
        {
            var result = await _commentService.CreateAsync(dto, ModelState);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> DeleteBlogComment(int id)
        {
            await _commentService.DeleteAsync(id);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }


    }
}
