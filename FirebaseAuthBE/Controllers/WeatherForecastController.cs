using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace FirebaseAuthBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WeatherForecast Get()
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 23,
                Summary = Summaries[1]
            };
        }

        [Route("/Count")]
        [HttpGet]
        public Count CurrentCount()
        {
            return new Count
            {
               currentCount = 0,
               userName = "Anonymous"
            };
        }

        [Route("/SecureCount")]
        [HttpGet, Authorize]
        public Count SecureCurrentCount()
        {
            var currentUser = HttpContext.User;
            var userName = currentUser.Claims.ToList().Where(a => a.Type == "name").FirstOrDefault().ToString();

            return new Count
            {
                currentCount = 1,
                userName = userName
            };
        }
    }
}
