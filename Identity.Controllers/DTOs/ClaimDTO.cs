using System.Security.Claims;

namespace Identity.Controllers.DTOs
{
    internal abstract class ClaimDTO : UserDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }

    internal class ReplaceClaimDTO : UserDTO
    {
        public Claim Claim { get; set; }

        public Claim NewClaim { get; set; }
    }

    internal class RemoveClaimDTO : ClaimDTO
    {
    }

    internal class AddClaimDTO : ClaimDTO
    {
    }
}
