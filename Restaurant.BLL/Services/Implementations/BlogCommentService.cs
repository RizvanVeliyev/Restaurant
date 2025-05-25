using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Dtos.BlogCommentDtos;
using Restaurant.BLL.Dtos.CommentDtos;
using Restaurant.BLL.Exceptions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;
using System.Security.Claims;

namespace Restaurant.BLL.Services.Implementations
{
    public class BlogCommentService : IBlogCommentService
    {
        private readonly IBlogCommentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IBlogService _blogService;
        private readonly ErrorLocalizer _errorLocalizer;
        private readonly IOrderService _orderService;

        public BlogCommentService(IBlogCommentRepository repository, IMapper mapper, IHttpContextAccessor contextAccessor, IBlogService blogService, ErrorLocalizer errorLocalizer, IOrderService orderService)
        {
            _repository = repository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _blogService = blogService;
            _errorLocalizer = errorLocalizer;
            _orderService = orderService;
        }

        public async Task<bool> CreateAsync(BlogCommentCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            if (!_checkAuthorized())
                throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var blog = await _blogService.GetAsync(dto.BlogId);

            var orders = await _orderService.GetAllAsync();

            var userId = _getUserId();


            //var isExist = await _repository.IsExistAsync(x => x.BlogId == dto.BlogId && x.AppUserId == userId);

            //if (isExist)
            //    throw new AlreadyExistException(_errorLocalizer.GetValue(nameof(AlreadyExistException)));

            //var isBought = orders.Any(x => x.AppUserId == userId && x.OrderItems.Any(x => x.Blog.Id == blog.Id));

            //if (!isBought)
            //    throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var comment = _mapper.Map<BlogComment>(dto);

            comment.AppUserId = userId;
            comment.CreatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System"; // İstifadəçi adı və ya "System"
            comment.UpdatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System"; // İstifadəçi adı və ya "System"


            await _repository.CreateAsync(comment);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateReplyAsync(BlogCommentReplyDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            if (!_checkAuthorized())
                throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var blog = await _blogService.GetAsync(dto.ProductId);

            var orders = await _orderService.GetAllAsync();

            var userId = _getUserId();




            //var isExist = await _repository.IsExistAsync(x => x.ProductId == dto.ProductId && x.AppUserId == userId);

            //if (isExist)
            //    throw new AlreadyExistException(_errorLocalizer.GetValue(nameof(AlreadyExistException)));

            //var isBought = orders.Any(x => x.AppUserId == userId && x.OrderItems.Any(x => x.Product.Id == blog.Id));

            //if (!isBought)
            //    throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var parentComment = await _repository.GetAsync(dto.ParentId);
            if (parentComment == null) throw new NotFoundException("Parent comment not found");

            var replyComment = _mapper.Map<BlogComment>(dto);
            replyComment.AppUserId = userId;
            replyComment.CreatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System";
            replyComment.UpdatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System"; 

            replyComment.Parent = parentComment;

            await _repository.CreateAsync(replyComment);
            await _repository.SaveChangesAsync();


            return true;
        }


        public async Task<bool> CheckIsAllowBlogCommentAsync(int blogId)
        {
            var blog = await _blogService.GetAsync(blogId);

            var orders = await _orderService.GetAllAsync();

            var userId = _getUserId();


            var isExist = await _repository.IsExistAsync(x => x.BlogId == blogId && x.AppUserId == userId);

            if (isExist)
                return false;

            //var isBought = orders.Any(x => x.AppUserId == userId && x.OrderItems.Any(x => x.Blog.Id == blog.Id));

            //if (!isBought)
            //    return false;

            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await _repository.GetAsync(id);

            if (comment is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var userId = _getUserId();

            if (comment.AppUserId != userId && !_isAdmin())
                throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            _repository.Delete(comment);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<BlogCommentGetDto>> GetBlogCommentsAsync(int blogId)
        {
            var blogComments = await _repository.GetFilter(
                              x => x.BlogId == blogId && x.ParentId == null,
                              x => x.Include(x => x.AppUser)
                                   .Include(x => x.Children)
                                      .ThenInclude(child => child.AppUser)
                          ).ToListAsync();
            var dtos = _mapper.Map<List<BlogCommentGetDto>>(blogComments);

            return dtos;
        }

        public Task<List<BlogCommentGetDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogCommentGetDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogCommentUpdateDto> GetUpdatedDtoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BlogCommentUpdateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        private string _getUserId()
        {
            return _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        }

        private bool _checkAuthorized()
        {
            return _contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }

        private bool _isAdmin()
        {
            return _contextAccessor.HttpContext?.User.IsInRole(IdentityRoles.Admin.ToString()) ?? false;
        }
    }
}

