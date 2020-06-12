using Microsoft.AspNetCore.Http;

namespace Counter.Services
{
    public interface ISecurityService
    {
        string GetUserID(HttpContext httpContext);
    }
}
