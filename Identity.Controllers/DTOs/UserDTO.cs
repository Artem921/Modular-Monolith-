using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Controllers.DTOs
{
    internal abstract class UserDTO
    {
        public User User { get; set; }
    }

    internal class AddLoginDTO : UserDTO
    {
        public UserLoginInfo LoginInfo { get; set; }
    }

    internal class PasswordHashDTO : UserDTO
    {
        public string Hash { get; set; }
    }
}
