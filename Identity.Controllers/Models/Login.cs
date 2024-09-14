namespace Identity.Controllers.Models
{
    internal class Login
    {
        public string Name {  get; set; }
        public string Password {  get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}


