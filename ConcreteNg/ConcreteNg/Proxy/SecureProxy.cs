using ConcreteNg.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Net;

namespace ConcreteNg.Proxy
{
    public class SecureProxy : ISubject
    {
        private readonly ISubject subject;

        public SecureProxy(ISubject _subject)
        {
            subject = _subject;
        }

        public async Task ProcessRequest(UserTypeEnum? userType, RequestDelegate nextRequest, HttpContext context)
        {
            bool isAuthorized = true;
            var controllerActionDescriptor = context
                .GetEndpoint()
                .Metadata
                .GetMetadata<ControllerActionDescriptor>();

            if (controllerActionDescriptor.EndpointMetadata.Any(x => x is AuthorizeRoles))
            {
                var authorizeAttribute = (AuthorizeRoles)controllerActionDescriptor.EndpointMetadata.FirstOrDefault(x => x is AuthorizeRoles);
                var role = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), authorizeAttribute.Role);

                if (!role.HasFlag(userType))
                {
                    isAuthorized = false;
                    await ReturnErrorResponse(context);
                }
            }
            if(isAuthorized)
            {
                await subject.ProcessRequest(userType, nextRequest, context);
            }
        }

        private async Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Response.WriteAsJsonAsync(new { message = "Forbidden" });
            await context.Response.StartAsync();
        }
 
    }
    
}
