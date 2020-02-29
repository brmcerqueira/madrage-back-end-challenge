using MadrageBackEndChallenge.Business;
using MadrageBackEndChallenge.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadrageBackEndChallenge.Web.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        
        [HttpPost("signIn")]
        public string SignIn(SignInModel model)
        {
            return _service.SignIn(model);
        }
        
        [HttpPost]
        public void Save(UserSaveModel model)
        {
            _service.Save(model);
        }
    }
}