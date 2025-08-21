namespace PersonalBlog.Services
{
    public class AuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAdminLoggedIn()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            return session?.GetString("IsAdmin") == "true";
        }
    }

}
