using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProductService _productService;
        private readonly ErrorLocalizer _errorLocalizer;
        private readonly IOrderService _orderService;

        public CommentService(ICommentRepository repository, IMapper mapper, IHttpContextAccessor contextAccessor, IProductService productService, ErrorLocalizer errorLocalizer, IOrderService orderService)
        {
            _repository = repository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _productService = productService;
            _errorLocalizer = errorLocalizer;
            _orderService = orderService;
        }

        public async Task<bool> CreateAsync(CommentCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            if (!_checkAuthorized())
                throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var product = await _productService.GetAsync(dto.ProductId);

            var orders = await _orderService.GetAllAsync();

            var userId = _getUserId();


            //var isExist = await _repository.IsExistAsync(x => x.ProductId == dto.ProductId && x.AppUserId == userId);

            //if (isExist)
            //    throw new AlreadyExistException(_errorLocalizer.GetValue(nameof(AlreadyExistException)));

            //var isBought = orders.Any(x => x.AppUserId == userId && x.OrderItems.Any(x => x.Product.Id == product.Id));

            //if (!isBought)
            //    throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var comment = _mapper.Map<Comment>(dto);

            comment.AppUserId = userId;
            comment.CreatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System"; // İstifadəçi adı və ya "System"
            comment.UpdatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System"; // İstifadəçi adı və ya "System"


            await _repository.CreateAsync(comment);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateReplyAsync(CommentReplyDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            if (!_checkAuthorized())
                throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var product = await _productService.GetAsync(dto.ProductId);

            var orders = await _orderService.GetAllAsync();

            var userId = _getUserId();

            


            //var isExist = await _repository.IsExistAsync(x => x.ProductId == dto.ProductId && x.AppUserId == userId);

            //if (isExist)
            //    throw new AlreadyExistException(_errorLocalizer.GetValue(nameof(AlreadyExistException)));

            //var isBought = orders.Any(x => x.AppUserId == userId && x.OrderItems.Any(x => x.Product.Id == product.Id));

            //if (!isBought)
            //    throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            var parentComment = await _repository.GetAsync(dto.ParentId);
            if (parentComment == null) throw new NotFoundException("Parent comment not found");

            var replyComment = _mapper.Map<Comment>(dto);
            replyComment.AppUserId = userId;
            replyComment.CreatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System";
            replyComment.UpdatedBy = _contextAccessor.HttpContext?.User.Identity?.Name ?? "System";

            replyComment.Parent = parentComment;

            await _repository.CreateAsync(replyComment);
            await _repository.SaveChangesAsync();


            return true;
        }

        public async Task<bool> CheckIsAllowCommentAsync(int productId)
        {
            var product = await _productService.GetAsync(productId);

            var orders = await _orderService.GetAllAsync();

            var userId = _getUserId();


            var isExist = await _repository.IsExistAsync(x => x.ProductId == productId && x.AppUserId == userId);

            if (isExist)
                return false;

            //var isBought = orders.Any(x => x.AppUserId == userId && x.OrderItems.Any(x => x.Product.Id == product.Id));

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

        public async Task<List<CommentGetDto>> GetProductCommentsAsync(int productId)
        {
            var comments = await _repository.GetFilter(
                   x => x.ProductId == productId && x.ParentId == null,
                   x => x.Include(x => x.AppUser)
                        .Include(x => x.Children) 
                           .ThenInclude(child => child.AppUser) 
               ).ToListAsync();
            var dtos = _mapper.Map<List<CommentGetDto>>(comments);

            return dtos;
        }

        public Task<List<CommentGetDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CommentGetDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CommentUpdateDto> GetUpdatedDtoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CommentUpdateDto dto, ModelStateDictionary ModelState)
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