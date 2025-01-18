using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.BLL.Services.Abstractions;
using Restaurant.BLL.Services.Implementations;
using Restaurant.BLL.UI.Services.Abstractions;
using Restaurant.BLL.UI.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL
{
    public static class BusinessLogicLayerServicesRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            AddServices(services);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddHttpContextAccessor();

            //services.AddFluentValidationAutoValidation();
            //services.AddValidatorsFromAssemblyContaining(typeof(ProductCreateDtoValidator));

            return services;
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAvaiabletimeService, AvaiabletimeService>();
            services.AddScoped<IBlogCategoryService, BlogCategoryService>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICheckoutService, CheckoutService>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IBlogCommentService, BlogCommentService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddScoped<ISubscribeService, SubscribeService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ILayoutService, LayoutService>();
        }
    }
}
