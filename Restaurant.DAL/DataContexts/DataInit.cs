using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Core.Entities;
using Restaurant.DAL.Enums;

namespace Restaurant.DAL.DataContexts
{
    public class DataInit
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppUser _admin;
        private readonly string _adminPassword;

        public DataInit(AppDbContext appDbContext, UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration,
            AppUser admin, string password)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _admin = admin;
            _adminPassword = password;
        }

        public async Task SeedDataAsync()
        {
            await _appDbContext.Database.MigrateAsync();
            await _addRolesAsync();
            await _addAdminAsync();
        }

        private async Task _addRolesAsync()
        {
            foreach (var r in Enum.GetNames(typeof(IdentityRoles)))
            {
                if (await _roleManager.Roles.AnyAsync(x => x.Name == r))//Tostring() lazim  olmadi!, onsuzda enum.getnames() bize string deyerler qaytarir.
                    continue;

                IdentityRole role = new() { Name = r };

                await _roleManager.CreateAsync(role);
            }
        }

        private async Task _addAdminAsync()
        {
            var existUser = await _userManager.FindByNameAsync(_admin.UserName ?? "");
            if (existUser is not null)
                return;
            await _userManager.CreateAsync(_admin, _adminPassword);
            await _userManager.AddToRoleAsync(_admin, IdentityRoles.Admin.ToString());
        }
    }
}
