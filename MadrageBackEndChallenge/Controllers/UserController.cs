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
        
        [HttpGet]
        public object[] All(int? index, int? limit)
        {
            return _service.All(index, limit);
        }
        
        [HttpPost]
        public void Save(UserSaveModel model)
        {
            _service.Save(model);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}