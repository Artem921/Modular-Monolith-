using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utils.Module;

namespace Identity.Infrastructure
{
    internal class IdentityInfrastructureModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(option => option.UseNpgsql(Configuration.GetConnectionString("BodyCarBd")));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<UserDbContext>();
        }
    }
}
