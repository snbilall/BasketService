using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool CheckUserIdHeader(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Request.Headers.ContainsKey("UserId");
        }

        public static string? GetUserIdHeader(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext.Request.Headers.ContainsKey("UserId"))
            {
                return httpContextAccessor.HttpContext.Request.Headers["UserId"];
            }
            return null;
        }
    }
}
