using MadrageBackEndChallenge.Business;
using MadrageBackEndChallenge.Business.Dtos;
using MadrageBackEndChallenge.Web.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize("Bearer")]
        [HttpPost]
        public override void Save(MenuSaveModel model)
        {
            base.Save(model);
        }
    }
}