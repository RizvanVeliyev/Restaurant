using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Entities;
using Restaurant.DAL.DataContexts;
using Restaurant.DAL.Helpers;
using Restaurant.DAL.Localizers;
using Restaurant.DAL.Repositories.Abstractions;
using Restaurant.DAL.Repositories.Implementations;


namespace Restaurant.DAL
{
    public static class DataAccessLayerServicesRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"),
            builder =>
            {
                builder.MigrationsAssembly("Restaurant.DAL");
            }));

            services.AddScoped<DataInit>();



            _addRepositories(services);
            _addIdentity(services);
            _addLocalizers(services);


            return services;
        }


        private static void _addRepositories(IServiceCollection services)
        {
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAvailableTimeRepository, AvailableTimeRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICheckoutRepository, CheckoutRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IBlogCommentRepository, BlogCommentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<ISubscribeRepository, SubscribeRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();


        }

        private static void _addLocalizers(IServiceCollection services)
        {

            services.AddSingleton<ErrorLocalizer>();
            services.AddSingleton<ContactLocalizer>();
            services.AddSingleton<OrderLocalizer>();
            services.AddSingleton<CartLocalizer>();
            services.AddSingleton<LayoutLocalizer>();
            services.AddSingleton<ShopLocalizer>();
            services.AddSingleton<BlogLocalizer>();
            services.AddSingleton<MenuLocalizer>();
            services.AddSingleton<ReservationLocalizer>();
            services.AddSingleton<AccountLocalizer>();
            services.AddSingleton<AboutLocalizer>();

        }



        private static void _addIdentity(IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 7;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<CustomIdentityErrorDescriber>();
        }
    }
}
