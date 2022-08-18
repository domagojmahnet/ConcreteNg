using ConcreteNg.Shared.Enums;

namespace ConcreteNg.Proxy
{
    public interface ISubject
    {
        Task ProcessRequest(UserTypeEnum? userType, RequestDelegate nextRequest, HttpContext context);
    }
}
