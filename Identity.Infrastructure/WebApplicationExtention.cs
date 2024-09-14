using Identity.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure
{
    public static class WebApplicationExtention
    {
        public static void InitializerDataBase(this WebApplication provider)
        {
            using (var scope = provider.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<Role>>();
                DatabaseInitializer.Initializer(userManager, roleManager);
            }
        }
    }
}
