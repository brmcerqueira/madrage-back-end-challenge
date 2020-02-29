using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadrageBackEndChallenge.Web.Controllers
{
    [ApiController]
    [Route("/menu")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }
    }
}