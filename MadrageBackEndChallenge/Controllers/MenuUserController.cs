using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadrageBackEndChallenge.Web.Controllers
{
    [ApiController]
    [Route("/menu-user")]
    public class MenuUserController : ControllerBase
    {
        private readonly ILogger<MenuUserController> _logger;

        public MenuUserController(ILogger<MenuUserController> logger)
        {
            _logger = logger;
        }
    }
}