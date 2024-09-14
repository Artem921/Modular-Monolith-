
using Identity.Domain.Entities;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Identity.Controllers.DTOs;

namespace Identity.Controllers
{
    [Route("users")]
    [ApiController]
    internal class UsersApiController : ControllerBase
    {
        /// <summary>
        /// UserStore Представляет новый экземпляр хранилища сохраняемости для пользователей, используя реализацию IdentityUser
        /// </summary>
        private readonly UserStore<User, Role, UserDbContext> userStore;

        private readonly ILogger<UsersApiController> Logger;

        public UsersApiController(UserDbContext context, ILogger<UsersApiController> logger)
        {
            userStore = new UserStore<User, Role, UserDbContext>(context);
            Logger = logger;
        }

        #region Users
        [HttpGet("AllUsers")]
        public async Task<IEnumerable<User>> GetAllUsersAsync() => await userStore.Users.ToArrayAsync();

        [HttpPost("UserId")]
        public async Task<string> GetUserIdAsync([FromBody] User user) => await userStore.GetUserIdAsync(user);

        [HttpPost("UserName")]
        public async Task<string> GetUserNameAsync([FromBody] User user) => await userStore.GetUserNameAsync(user);

        [HttpPost("UserName/{name}")]
        public async Task SetUserNameAsync([FromBody] User user, string name, [FromServices] ILogger<UsersApiController> logger)
        {
            logger.LogInformation("Изменение имя пользователя", user.Id, name);

            await userStore.SetUserNameAsync(user, name);

            await userStore.UpdateAsync(user);

        }

        [HttpPost("NormalUserName")]
        public async Task<string> GetNormalizedUserNameAsync([FromBody] User user) => await userStore.GetNormalizedUserNameAsync(user);

        [HttpPost("SetNormalUserName/{normalizedName}")]
        public async Task SetNormalizedNameAsync([FromBody] User user, string normalizedName)
        {
            Logger.LogInformation("Изменение  нормализованного имя пользователя", user.Id, normalizedName);

            await userStore.SetNormalizedUserNameAsync(user, normalizedName);

            await userStore.UpdateAsync(user);
        }

        [HttpPost("SetNormalEmail/{normalizedEmail}")]
        public async Task SetNormalizedEmailAsync([FromBody] User user, string normalizedEmail)
        {
            await userStore.SetNormalizedEmailAsync(user, normalizedEmail);

            await userStore.UpdateAsync(user);
        }


        [HttpPost("User")]
        public async Task<bool> CreateAsync([FromBody] User user)
        {

            var result = await userStore.CreateAsync(user);
            if (result.Succeeded) Logger.LogInformation("Пользователь создан", user.UserName);
            else Logger.LogWarning("Ошибка при создании пользователя", user.UserName,
                string.Join(",", result.Errors.Select(error => error.Description)));
            return result.Succeeded;
        }

        [HttpGet("User/Find/{id}")]
        public async Task<User> FindByIdAsync(string id) => await userStore.FindByIdAsync(id);

        [HttpGet("User/Normal/{name}")]
        public async Task<User> FindByNameAsync(string name) => await userStore.FindByNameAsync(name);

        [HttpGet("User/findByEmail/{normalizedEmail}")]
        public async Task<User> FindByEmailAsync(string normalizedEmail) => await userStore.FindByEmailAsync(normalizedEmail);

        [HttpPost("Roles")]
        public async Task<IList<string>> GetRolesAsync([FromBody] User user)
        {
            return await userStore.GetRolesAsync(user);
        }

        [HttpPost("inrole/{roleName}")]
        public async Task<bool> IsIntRoleAsync([FromBody] User user, string roleName)
        {
            return await userStore.IsInRoleAsync(user, roleName);
        }

        [HttpGet("usersInRole/{roleName}")]
        public async Task<IList<User>> GetUsersIsIntRoleAsync(string roleName)
        {
            return await userStore.GetUsersInRoleAsync(roleName);
        }

        [HttpPost("Role/{role}")]
        public async Task AddToRoleAsync([FromBody] User user, string role, [FromServices] UserDbContext context)
        {
            await userStore.AddToRoleAsync(user, role);

            await context.SaveChangesAsync();
        }

        [HttpPost("GetPasswordHash")]
        public async Task<string> GetPasswordHashAsync([FromBody] User user) => await userStore.GetPasswordHashAsync(user);

        [HttpPost("SetPasswordHash")]
        public async Task<string> SetPasswordHashAsync([FromBody] PasswordHashDTO hash)
        {
            await userStore.SetPasswordHashAsync(hash.User, hash.Hash);

            await userStore.UpdateAsync(hash.User);

            return hash.User.PasswordHash;
        }

        [HttpPost("HasPasswordHash")]
        public async Task<bool> HasPasswordHashAsync([FromBody] User user) => await userStore.HasPasswordAsync(user);

        [HttpPut("UserUpdate")]
        public async Task<bool> UpdateAsync([FromBody] User user) => (await userStore.UpdateAsync(user)).Succeeded;
        #endregion

        #region Claims

        //[HttpPost("GetClaims")]
        //public async Task<IList<Claim>> GetClaimsAsync([FromBody] User user) => await userStore.GetClaimsAsync(user);

        [HttpPost("AddClaims")]
        public async Task AddClaimsAsync([FromBody] AddClaimDTO claimInfo, [FromServices] UserDbContext context)
        {
            await userStore.AddClaimsAsync(claimInfo.User, claimInfo.Claims);
            await context.SaveChangesAsync();
        }

        [HttpPost("ReplaceClaims")]
        public async Task ReplaceClaimsAsync([FromBody] ReplaceClaimDTO claimInfo, [FromServices] UserDbContext context)
        {
            await userStore.ReplaceClaimAsync(claimInfo.User, claimInfo.Claim, claimInfo.NewClaim);
            await context.SaveChangesAsync();
        }

        [HttpPost("RemoveClaims")]
        public async Task RemoveClaimsAsync([FromBody] RemoveClaimDTO claimInfo, [FromServices] UserDbContext context)
        {
            await userStore.RemoveClaimsAsync(claimInfo.User, claimInfo.Claims);
            await context.SaveChangesAsync();
        }

        [HttpPost("GetUsersForClaim")]
        public async Task<IList<User>> GetUsersFormClaimAsync([FromBody] Claim claim) => await userStore.GetUsersForClaimAsync(claim);

        #endregion

        #region TwoFactor

        [HttpPost("GetTwoFactorEnabled")]
        public async Task<bool> GetTwoFactorEnabledAsync([FromBody] User user) => await userStore.GetTwoFactorEnabledAsync(user);

        [HttpPost("SetTwoFactor/{enabled}")]
        public async Task SetTwoFactorEnabledAsync([FromBody] User user, bool enabled)
        {
            await userStore.SetTwoFactorEnabledAsync(user, enabled);
            await userStore.UpdateAsync(user);
        }

        #endregion

        #region Email

        [HttpPost("GetEmail")]
        public async Task<string> GetEmailAsync([FromBody] User user) => await userStore.GetEmailAsync(user);

        [HttpPost("SetEmail/{email}")]
        public async Task SetEmailAsync([FromBody] User user, string email)
        {
            await userStore.SetEmailAsync(user, email);
            await userStore.UpdateAsync(user);
        }

        #endregion

        #region Login
        [HttpPost("AddLogin")]
        public async Task AddLoginAsync([FromBody] AddLoginDTO login, [FromServices] UserDbContext context)
        {
            await userStore.AddLoginAsync(login.User, login.LoginInfo);
            await context.SaveChangesAsync();
        }
        [HttpPost("GetLogin")]
        public async Task<IList<UserLoginInfo>> GetLoginAsync([FromBody] User user) => await userStore.GetLoginsAsync(user);
        #endregion
    }
}
