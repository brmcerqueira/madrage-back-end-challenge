using MadrageBackEndChallenge.Business;
using Microsoft.AspNetCore.Authorization;
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
        
        [Authorize("Bearer")]
        [HttpPost]
        public void Grant(int menuId, int userId)
        {
            _service.Grant(menuId, userId);
        }
        
        [Authorize("Bearer")]
        [HttpDelete]
        public void Delete(int menuId, int userId)
        {
            _service.Delete(menuId, userId);
        }
    }
}