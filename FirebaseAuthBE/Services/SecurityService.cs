using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Counter.Services
{
    public class SecurityService : ISecurityService
    {
        const string firebaseUserId = "user_id";

        public string GetUserID(HttpContext httpContext)
        {
            var currentUser = httpContext.User;
            return currentUser.Claims.ToList().Where(a => a.Type == firebaseUserId).FirstOrDefault().ToString();
        }
    }
}