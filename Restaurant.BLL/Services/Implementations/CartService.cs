using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Restaurant.BLL.Dtos.CartItemDtos;
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
    internal class CartService : ICartService
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProductService _productService;
        private readonly ErrorLocalizer _errorLocalizer;
        private const string BASKET_KEY = "RestaurantCart";

        public CartService(ICartItemRepository repository, IMapper mapper, IHttpContextAccessor contextAccessor, IProductService productService, ErrorLocalizer errorLocalizer)
        {
            _repository = repository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _productService = productService;
            _errorLocalizer = errorLocalizer;
        }

        public async Task<bool> AddToCartAsync(int id, int count = 1)
        {
            var isExistProductSize = await _productService.IsExistAsync(id);

            if (isExistProductSize is false)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));


            if (count < 1)
                count = 1;

            if (_checkAuthorized())
            {
                string userId = _getUserId();

                var existCartItem = await _repository.GetAsync(x => x.ProductId == id && x.AppUserId == userId);

                if (existCartItem is { })
                {
                    existCartItem.Count += count;

                    _repository.Update(existCartItem);
                    await _repository.SaveChangesAsync();

                    return true;
                }

                CartItem cartItem = new() { AppUserId = userId, ProductId = id, Count = count };

                await _repository.CreateAsync(cartItem);
                await _repository.SaveChangesAsync();

                return true;
            }
            else
            {
                var cartItems = _readCartFromCookie();

                var existItem = cartItems.FirstOrDefault(x => x.ProductId == id);

                if (existItem is { })
                    existItem.Count += count;
                else
                {
                    CartItem newCartItem = new() { ProductId = id, Count = count };

                    cartItems.Add(newCartItem);
                }

                _writeCartInCookie(cartItems);

                return true;
            }
        }


        public async Task<bool> DecreaseToCartAsync(int id)
        {
            var isExistProductSize = await _productService.IsExistAsync(id);

            if (isExistProductSize is false)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            if (_checkAuthorized())
            {
                string userId = _getUserId();

                var existCartItem = await _repository.GetAsync(x => x.ProductId == id && x.AppUserId == userId);

                if (existCartItem is null)
                    throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

                if (existCartItem.Count <= 1)
                    return true;

                existCartItem.Count--;

                _repository.Update(existCartItem);
                await _repository.SaveChangesAsync();

                return true;

            }
            else
            {
                var cartItems = _readCartFromCookie();

                var existItem = cartItems.FirstOrDefault(x => x.ProductId == id);

                if (existItem is null)
                    throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

                if (existItem.Count <= 1)
                    return true;

                existItem.Count--;

                _writeCartInCookie(cartItems);

                return true;
            }
        }

        public async Task RemoveToCartAsync(int id)
        {
            var isExistProductSize = await _productService.IsExistAsync(id);

            if (isExistProductSize is false)
                throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

            if (_checkAuthorized())
            {
                string userId = _getUserId();

                var existCartItem = await _repository.GetAsync(x => x.ProductId == id && x.AppUserId == userId);

                if (existCartItem is null)
                    throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

                _repository.Delete(existCartItem);
                await _repository.SaveChangesAsync();
            }
            else
            {
                List<CartItem> cartItems = _readCartFromCookie();

                var existItem = cartItems.FirstOrDefault(x => x.ProductId == id);

                if (existItem is null)
                    throw new NotFoundException(_errorLocalizer.GetValue(nameof(NotFoundException)));

                cartItems.Remove(existItem);

                _writeCartInCookie(cartItems);
            }
        }

        public async Task<CartGetDto> GetCartAsync(Languages language = Languages.Azerbaijan)
        {
            if (_checkAuthorized())
            {
                var userId = _getUserId();

                LanguageHelper.CheckLanguageId(ref language);

                var cartItems = await _repository.GetFilter(x => x.AppUserId == userId,
                               x => x.Include(x => x.Product)
                                          .ThenInclude(x => x.ProductDetails.Where(x => x.LanguageId == (int)language))
                                          .Include(x => x.Product.Category.CategoryDetails.Where(x => x.LanguageId == (int)language))
                                          .Include(x => x.Product.ProductImages)).ToListAsync();

                var dtos = _mapper.Map<List<CartItemGetDto>>(cartItems);

                decimal totalPrice = dtos.Sum(x => x.Count * x.Product.Price);
                var cartDto = new CartGetDto()
                {
                    Items = dtos,
                    Count = dtos.Count,
                    Subtotal = totalPrice,
                    Total = totalPrice,
                    Discount = 0,
                };

                return cartDto;
            }
            else
            {
                var cartItems = _readCartFromCookie();

                var dtos = _mapper.Map<List<CartItemGetDto>>(cartItems);

                foreach (var dto in dtos)
                {
                    var product = await _productService.GetAsync(dto.ProductId, language);

                    if (product is null)
                    {
                        dtos.Remove(dto);
                        continue;
                    }

                    dto.Product = product;
                }

                decimal totalPrice = dtos.Sum(x => (x.Count * x.Product.Price));
                var cartDto = new CartGetDto()
                {
                    Items = dtos,
                    Count = dtos.Count,
                    Subtotal = totalPrice,
                    Total = totalPrice,
                    Discount = 0,
                };

                return cartDto;
            }

        }

        public async Task ClearCartAsync()
        {
            if (!_checkAuthorized())
            {
                _writeCartInCookie(new());
                return;
            }

            string userId = _getUserId();

            var cartItems = await _repository.GetFilter(x => x.AppUserId == userId).ToListAsync();

            foreach (var cartItem in cartItems)
            {
                _repository.Delete(cartItem);
            }

            await _repository.SaveChangesAsync();
        }


        private List<CartItem> _readCartFromCookie()
        {
            string json = _contextAccessor.HttpContext?.Request.Cookies[BASKET_KEY] ?? "";

            var cartItems = JsonConvert.DeserializeObject<List<CartItem>>(json) ?? new();
            return cartItems;
        }

        private void _writeCartInCookie(List<CartItem> cartItems)
        {
            string newJson = JsonConvert.SerializeObject(cartItems);

            _contextAccessor.HttpContext?.Response.Cookies.Append(BASKET_KEY, newJson);
        }


        private string _getUserId()
        {
            return _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
        }


        private bool _checkAuthorized()
        {
            return _contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }

        
    }
}
