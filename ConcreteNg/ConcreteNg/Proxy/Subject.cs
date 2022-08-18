using ConcreteNg.Shared.Enums;

namespace ConcreteNg.Proxy
{

    public class Subject : ISubject
    {
        public async Task ProcessRequest(UserTypeEnum? userType, RequestDelegate nextRequest, HttpContext context)
        {
            await nextRequest(context);
        }
    }
}
