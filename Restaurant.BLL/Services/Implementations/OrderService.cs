using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json.Linq;
using Restaurant.BLL.Dtos;
using Restaurant.BLL.Dtos.OrderDtos;
using Restaurant.BLL.Dtos.OrderItemDtos;
using Restaurant.BLL.Exceptions;
using Restaurant.BLL.Extensions;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;
using System.Security.Claims;

namespace Restaurant.BLL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IStatusService _statusService;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ErrorLocalizer _errorLocalizer;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IPaymentService _paymentService;

        public OrderService(IOrderRepository repository, IMapper mapper, ICartService cartService, IHttpContextAccessor contextAccessor, ErrorLocalizer errorLocalizer, IStatusService statusService, IProductService productService, IAuthService authService, IPaymentService paymentService)
        {
            _repository = repository;
            _mapper = mapper;
            _cartService = cartService;
            _contextAccessor = contextAccessor;
            _errorLocalizer = errorLocalizer;
            _statusService = statusService;
            _productService = productService;
            _authService = authService;
            _paymentService = paymentService;
        }


        public async Task CancelOrderAsync(int id)
        {
            var order = await _repository.GetAsync(id, x => x.Include(x => x.OrderItems));

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var status = await _statusService.GetLastAsync();

            if (order.StatusId == status.Id)
                return;

            order.StatusId = status.Id;

            _repository.Update(order);
            await _repository.SaveChangesAsync();


            //foreach (var item in order.OrderItems)
            //    await _productService.DecreaseSalesCountAsync(item.ProductId, item.Count);


        }


        public async Task RepairOrderAsync(int id)
        {
            var order = await _repository.GetAsync(id, x => x.Include(x => x.OrderItems));

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var status = await _statusService.GetFirstAsync();

            if (order.StatusId == status.Id)
                return;

            order.StatusId = status.Id;

            _repository.Update(order);
            await _repository.SaveChangesAsync();


            //foreach (var item in order.OrderItems)
            //    await _productService.IncreaseSalesCountAsync(item.ProductId, item.Count);


        }

        public async Task<bool> CreateAsync(OrderCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var cart = await _cartService.GetCartAsync();

            if (cart.Count is 0)
                throw new EmptyCartException(_errorLocalizer.GetValue(nameof(EmptyCartException)));

            dto.OrderItems = _mapper.Map<List<OrderItemCreateDto>>(cart.Items);

            var order = _mapper.Map<Order>(dto);

            string? userName = _contextAccessor.HttpContext?.User.Identity?.Name;

            // `CreatedBy` və `UpdatedBy` doldurulur
            order.CreatedBy = userName ?? "Unknown";
            order.UpdatedBy = userName ?? "Unknown";

            var status = await _statusService.GetFirstAsync();
            order.StatusId = status.Id;

            string userId = _getUserId()!;
            order.AppUserId = userId;

            await _repository.CreateAsync(order);
            await _repository.SaveChangesAsync();

            //foreach (var item in dto.OrderItems)
            //    await _productService.IncreaseSalesCountAsync(item.ProductId, item.Count);

            PaymentCreateDto paymentDto = new()
            {
                Description = "Dannys Odenis",
                Amount = order.TotalPrice,
                OrderId = order.Id,
            };

            var responseDto = await _paymentService.CreateAsync(paymentDto);


            _repository.Update(order);
            await _repository.SaveChangesAsync();

            if (_contextAccessor.HttpContext is not null)
            {
                string paymentUrl = $"{responseDto.Order.HppUrl}?id={responseDto.Order.Id}&password={responseDto.Order.Password}";
                _contextAccessor.HttpContext.Response.Cookies.Append("paymentUrl", paymentUrl, new CookieOptions() { Expires = DateTime.UtcNow.AddMinutes(1) });
            }


            await _cartService.ClearCartAsync();

            return true;
        }


        public async Task NextOrderStatusAsync(int id)
        {
            var order = await _repository.GetAsync(id, x => x.Include(x => x.OrderItems));

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            if (order.StatusId == 4)
                return;

            if (order.StatusId < 3)
                order.StatusId++;

            _repository.Update(order);
            await _repository.SaveChangesAsync();
        }

        public async Task PrevOrderStatusAsync(int id)
        {
            var order = await _repository.GetAsync(id, x => x.Include(x => x.OrderItems));

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            if (order.StatusId == 4)
                return;

            if (order.StatusId > 1)
                order.StatusId--;

            _repository.Update(order);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _repository.GetAsync(id);

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            _repository.Delete(order);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<OrderGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
        {
            var query = _repository.GetAll(_getIncludeFunc(language));

            var orders = await _repository.OrderByDescending(query, x => x.CreatedAt).ToListAsync();

            var dtos = _mapper.Map<List<OrderGetDto>>(orders);

            return dtos;
        }

        public async Task<OrderGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
        {
            var order = await _repository.GetAsync(id, _getIncludeFunc(language));

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<OrderGetDto>(order);

            return dto;
        }

        public async Task<OrderUpdateDto> GetUpdatedDtoAsync(int id)
        {
            var order = await _repository.GetAsync(id, _getIncludeFunc(Languages.Azerbaijan));

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            var dto = _mapper.Map<OrderUpdateDto>(order);

            return dto;
        }

        public async Task<bool> UpdateAsync(OrderUpdateDto dto, ModelStateDictionary ModelState) 
        {
            if (ModelState.IsValid)
                return false;

            var existOrder = await _repository.GetAsync(dto.Id, _getIncludeFunc(Languages.Azerbaijan));

            if (existOrder is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            existOrder = _mapper.Map(dto, existOrder);

            _repository.Update(existOrder);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<List<OrderGetDto>> GetUserOrdersAsync(Languages language = Languages.Azerbaijan)
        {
            string? userId = _getUserId();

            var query = _repository.GetFilter(x => x.AppUserId == userId, _getIncludeFunc(language));

            var orders = await _repository.OrderByDescending(query, x => x.CreatedAt).ToListAsync();

            var dtos = _mapper.Map<List<OrderGetDto>>(orders);

            return dtos;
        }

        public async Task<OrderGetDto> GetUserOrderAsync(int id, Languages language = Languages.Azerbaijan)
        {
            if (!_checkAuthorized())
                throw new UnAuthorizedException(_errorLocalizer.GetValue(nameof(UnAuthorizedException)));

            string userId = _getUserId()!;

            var order = await _repository.GetAsync(x => x.AppUserId == userId && x.Id == id, _getIncludeFunc(language));

            if (order is null)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));


            var dto = _mapper.Map<OrderGetDto>(order);

            return dto;
        }


        public async Task<OrderCreateDto> GetUserUnSubmitOrderAsync(Languages language = Languages.Azerbaijan)
        {
            var cart = await _cartService.GetCartAsync();

            OrderCreateDto dto = new();

            if (_checkAuthorized())
            {
                var userId = _getUserId()!;

                var user = await _authService.GetUserAsync(userId);

                dto.Name = user.Name;
                dto.Surname = user.Surname;
            }

            dto.OrderItems = _mapper.Map<List<OrderItemCreateDto>>(cart.Items);

            return dto;
        }


        private string? _getUserId()
        {
            return _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
        }

        private bool _checkAuthorized()
        {
            return _contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }


        private Func<IQueryable<Order>, IIncludableQueryable<Order, object>> _getIncludeFunc(Languages language)
        {
            LanguageHelper.CheckLanguageId(ref language);
            return x => x.Include(x => x.OrderItems).ThenInclude(x => x.Product.ProductDetails.Where(x => x.LanguageId == (int)language))
                                .Include(x => x.OrderItems).ThenInclude(x => x.Product.ProductImages)
                                .Include(x => x.Status.StatusDetails.Where(x => x.LanguageId == (int)language))
                                .Include(x => x.AppUser!);
        }

       
    }
}
