using System.Linq;
using System.Threading.Tasks;
using FoodProject.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodProject.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                PhoneNumber = "04x-xxx-xxx",
                EmailConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Admin123+");
                    await userManager.AddToRoleAsync(defaultUser, "User");
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }

            }
        }
    }
}