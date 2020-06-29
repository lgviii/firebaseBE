using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Counter.Services;
using Counter.Models;
using System.Threading.Tasks;

namespace FirebaseAuthBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestService : ControllerBase
    {
        private readonly ILogger<TestService> _logger;
        private readonly ICounterService _counterService;
        private readonly ISecurityService _securityService;

        public TestService(ILogger<TestService> logger, ICounterService counterService)
        {
            _logger = logger;
            _counterService = counterService;
            _securityService = new SecurityService();
        }

        [Route("/")]
        [HttpGet]
        public string DefaultIndex()
        {
            return "This is the index for Lin's experiment!";
        }

        [Route("/Alive")]
        [HttpGet]
        public string CurrentCount()
        {
            return "Server is alive!";
        }

        [Route("/Counter")]
        [HttpPost, Authorize]
        public async Task<CounterInfo> CreateCounter()
        {
            return await _counterService.AddCounter(_securityService.GetUserID(HttpContext));
        }

        [Route("/Counter")]
        [HttpGet, Authorize]
        public async Task<CounterInfo> GetCounter()
        {
            return await _counterService.GetCounter(_securityService.GetUserID(HttpContext));
        }

        [Route("/IncrementCounter")]
        [HttpPatch, Authorize]
        public async Task IncrementCounter()
        {
            await _counterService.IncrementCounter(_securityService.GetUserID(HttpContext));
        }
        
        [Route("/DecrementCounter")]
        [HttpPatch, Authorize]
        public async Task DecrementCounter()
        {
            await _counterService.DecrementCounter(_securityService.GetUserID(HttpContext));
        }
    }
}
