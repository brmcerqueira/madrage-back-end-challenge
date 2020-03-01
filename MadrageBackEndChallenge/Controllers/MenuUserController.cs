using MadrageBackEndChallenge.Business;
using Microsoft.AspNetCore.Mvc;

namespace MadrageBackEndChallenge.Web.Controllers
{
    [ApiController]
    [Route("/menu-user")]
    public class MenuUserController : ControllerBase
    {
        private readonly IMenuUserService _service;

        public MenuUserController(IMenuUserService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public void Grant(int menuId, int userId)
        {
            _service.Grant(menuId, userId);
        }
        
        [HttpDelete]
        public void Delete(int menuId, int userId)
        {
            _service.Delete(menuId, userId);
        }
    }
}