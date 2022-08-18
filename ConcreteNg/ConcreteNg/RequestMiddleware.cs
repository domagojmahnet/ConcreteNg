using ConcreteNg.Proxy;
using ConcreteNg.Shared.Enums;
using System.Net;
using System.Security.Claims;

namespace ConcreteNg
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RequestMiddleware(RequestDelegate _next, IHttpContextAccessor _httpContextAccessor)
        {
            next = _next;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var secureProxy = new SecureProxy(new Subject());
            UserTypeEnum? userType = null;
            if (!context.Request.Path.ToString().Contains("/login"))
            {
                userType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            }
            await secureProxy.ProcessRequest(userType, next, context);
        }
    }
}
