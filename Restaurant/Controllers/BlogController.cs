using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.Dtos.BlogCommentDtos;
using Restaurant.BLL.Dtos.CommentDtos;
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
        public async Task<IActionResult> Index(int? categoryId)
        {
            var blogs = await _blogService.GetAllAsync(_language);

            var blogCategories = await _blogCategoryService.GetAllAsync(_language);

            if (categoryId.HasValue && categoryId > 0)
            {
                blogs = blogs.Where(b => b.BlogCategoryId == categoryId.Value).ToList();
            }

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

            var allBlogs = await _blogService.GetAllAsync(_language);
            var currentIndex = allBlogs.FindIndex(b => b.Id == id);

            // Növbəti və əvvəlki blogları tapın
            var nextBlogId = currentIndex < allBlogs.Count - 1 ? allBlogs[currentIndex + 1].Id : (int?)null;
            var prevBlogId = currentIndex > 0 ? allBlogs[currentIndex - 1].Id : (int?)null;


            BlogDetailDto dto = new()
            {
                Blog = blog,
                BlogComments = comments,
                IsAllowBlogComment = isAllowBlogComment,
                NextBlogId = nextBlogId,
                PrevBlogId = prevBlogId
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

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> ReplyComment(BlogCommentReplyDto dto)
        {

            var result = await _commentService.CreateReplyAsync(dto, ModelState);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> DeleteBlogComment(int id)
        {
            await _commentService.DeleteAsync(id);

            string returnUrl = Request.GetReturnUrl();

            return Redirect(returnUrl);
        }





        [HttpPost]
        public IActionResult SubscribeNewsletter(string mc_email)
        {
            if (string.IsNullOrEmpty(mc_email))
            {
                // Əgər e-poçt boşdursa, istifadəçini səhifəyə yenidən qaytarın və xəbərdarlıq göstərin
                TempData["Error"] = "Please enter a valid email address.";
                return Redirect(Request.Headers["Referer"].ToString() + "#newsletter"); // Səhifəyə geri dön və `newsletter` hissəsinə fokuslan
            }

            // Newsletter üçün əlavə məntiq (məsələn, email saxlama və ya API çağırışı)
            TempData["Success"] = "Thank you for subscribing to our newsletter!";

            // İstifadəçini yenidən səhifəyə yönləndir və `newsletter` hissəsinə fokuslan
            return Redirect(Request.Headers["Referer"].ToString() + "#newsletter");
        }


    }
}
