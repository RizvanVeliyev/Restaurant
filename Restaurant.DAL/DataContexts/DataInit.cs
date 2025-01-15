﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;

namespace Restaurant.DAL.DataContexts
{
    public class DataInit
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly AppUser _admin;

        public DataInit(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

            _admin = _configuration.GetSection("AdminSettings").Get<AppUser>() ?? new();
        }


        public async Task InitDatabaseAsync()
        {
            await _context.Database.MigrateAsync();

            await _createRolesAsync();

            await _createAdminAsync();
        }

        private async Task _createAdminAsync()
        {
            var isExist = await _userManager.Users.AnyAsync(x => x.UserName == _admin.UserName);

            if (isExist)
                return;

            await _userManager.CreateAsync(_admin, _configuration["AdminSettings:Password"]!);

            await _userManager.AddToRoleAsync(_admin, IdentityRoles.Admin.ToString());

        }
        private async Task _createRolesAsync()
        {
            foreach (string role in Enum.GetNames(typeof(IdentityRoles)))
            {
                var isExist = await _roleManager.Roles.AnyAsync(x => x.Name == role);

                if (isExist)
                    continue;

                IdentityRole identityRole = new() { Name = role };

                await _roleManager.CreateAsync(identityRole);
            }
        }

    }
}
