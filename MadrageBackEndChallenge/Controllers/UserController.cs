using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadrageBackEndChallenge.Web.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
    }
}