using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTennis.DataAccess.DBContext;

namespace TableTennis.DataAccess
{
    public static class AccountInitializer
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private ApplicationDbContext context;

        //public AccountInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext _context)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    context = _context;
        //}

        public static void SeedData(IServiceProvider serviceProvider, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager)
        {

            var adminRole = new ApplicationRole("SuperAdmin");
            var userRole = new ApplicationRole("User");

            if (!_roleManager.Roles.Any())
            {
                var roles = new List<ApplicationRole>() { adminRole, userRole };
                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }
            }

            if (_userManager.Users.Any()) return;

            var adminUser = new ApplicationUser
            {
                UserName = "Tariqul",
                Email = "tariqul2814@gmail.com",
                PasswordHash = "Asd123@"
            };

            _userManager.CreateAsync(adminUser, "Asd123@").GetAwaiter().GetResult();
            //_userManager.CreateAsync(normalUser, "P@ssw0rd123").GetAwaiter().GetResult();

            _userManager.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();

            //_userManager.AddToRoleAsync(normalUser, adminRole.Name).GetAwaiter().GetResult();

        }
    }
}
