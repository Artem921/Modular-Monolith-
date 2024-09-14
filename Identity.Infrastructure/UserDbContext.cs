using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure
{
    internal class UserDbContext : IdentityDbContext<User, Role, string>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.Migrate();

        }
    }
}
