using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Dtos.CommentDtos;
using Restaurant.BLL.Exceptions;
using Restaurant.BLL.Services.Abstractions;
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
            var comments = await _repository.GetFilter(x => x.ProductId == productId, x => x.Include(x => x.AppUser)).ToListAsync();

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

        public Task<bool> CheckIsAllowCommentAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(CommentCreateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }
    }
}
