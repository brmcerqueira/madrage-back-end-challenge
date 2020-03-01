using MadrageBackEndChallenge.Business;
using MadrageBackEndChallenge.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadrageBackEndChallenge.Web.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : CrudController<IUserService, UserSaveModel>
    {
        public UserController(IUserService service) : base(service)
        {
            
        }
        
        [HttpPost("signIn")]
        public string SignIn(SignInModel model)
        {
            return Service.SignIn(model);
        }
    }
}