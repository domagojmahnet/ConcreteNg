using ConcreteNg.Shared.Enums;
using System.Net;

namespace ConcreteNg.Proxy
{
    public class SecureProxy : ISubject
    {
        private readonly ISubject subject;

        List<string> BuyerAccessibleRoutes = new List<string> 
        {
            "login",
            "user",
            "allProjects",
            "diaryItems/",
            "costOverview/"
        };

        public SecureProxy(ISubject _subject)
        {
            subject = _subject;
        }

        public async Task ProcessRequest(UserTypeEnum? userType, RequestDelegate nextRequest, HttpContext context)
        {
            /*if (userType == UserTypeEnum.Buyer && CheckBuyerPermissions(context))
            {
                await ReturnErrorResponse(context);
            }
            else
            {*/
                await subject.ProcessRequest(userType, nextRequest, context);
            //}
        }

        private async Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.StartAsync();
        }
        
        private bool CheckBuyerPermissions(HttpContext context)
        {
            return BuyerAccessibleRoutes.Any(s => context.Request.Path.ToString().Contains(s));
        }
    }
    
}
