using MadrageBackEndChallenge.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MadrageBackEndChallenge.Web.Controllers
{
    public abstract class CrudController<T, TSaveModel> : ControllerBase
        where T : ICrudService<TSaveModel>
    {
        protected T Service { get; }

        protected CrudController(T service)
        {
            Service = service;
        }
        
        [Authorize("Bearer")]
        [HttpGet]
        public object[] All(int? index, int? limit)
        {
            return Service.All(index, limit);
        }
        
        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return Service.Get(id);
        }
        
        [HttpPost]
        public virtual void Save(TSaveModel model)
        {
            Service.Save(model);
        }
        
        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Service.Delete(id);
        }
    }
}