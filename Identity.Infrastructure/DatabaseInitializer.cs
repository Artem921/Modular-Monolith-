using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Identity.Infrastructure
{
    internal static class DatabaseInitializer
    {
        internal static void Initializer(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (roleManager.FindByNameAsync(Role.RoleName).Result == null)
            {
                roleManager.CreateAsync(new Role { Name = Role.RoleName }).Wait();
            }
            if (userManager.FindByNameAsync(User.Login).Result == null)
            {
                var admin = new User { UserName = User.Login };
                var result = userManager.CreateAsync(admin, User.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Role.RoleName).Wait();
                    userManager.AddClaimAsync(admin, new Claim(ClaimTypes.Role, Role.RoleName)).Wait();
                }
                else
                {
                    var message = string.Join(", ", result.Errors.Select(x => "Code " + x.Code + " Description" + x.Description));
                    Console.WriteLine(message);

                }
            }
        }
    }
}