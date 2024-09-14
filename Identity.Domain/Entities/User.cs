using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities
{
    internal class User : IdentityUser
    {
        public const string Login = "Admin";
        public const string Password = "Aa123!";
    }
}
