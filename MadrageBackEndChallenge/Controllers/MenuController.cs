using MadrageBackEndChallenge.Business;
using MadrageBackEndChallenge.Business.Dtos;
using MadrageBackEndChallenge.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadrageBackEndChallenge.Web.Controllers
{
    [ApiController]
    [Route("/menu")]
    public class MenuController :  CrudController<ICrudService<IMenuSaveDto>, MenuSaveModel>
    {
        public MenuController(ICrudService<IMenuSaveDto> service) : base(service)
        {

        }
    }
}