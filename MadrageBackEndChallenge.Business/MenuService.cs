using System.Linq;
using MadrageBackEndChallenge.Business.Dtos;
using MadrageBackEndChallenge.Persistence.Daos;

namespace MadrageBackEndChallenge.Business
{
    public class MenuService : ICrudService<IMenuSaveDto>
    {
        private readonly IMenuDao _dao;

        public MenuService(IMenuDao dao)
        {
            _dao = dao;
        }
        public object[] All(int? index, int? limit)
        {
            // ReSharper disable once CoVariantArrayConversion
            return _dao.All(index, limit).Select(e => new
            {
                e.Id,
                e.Label,
                e.ParentId
            }).ToArray();
        }
        public object Get(int id)
        {
            var menu = _dao.Get(id);
            return new
            {
                menu.Label,
                menu.ParentId,
                Submenus = _dao.GetSubmenus(id).BuildMenuTreeNode()
            };
        }

        public void Save(IMenuSaveDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            _dao.Delete(id);
        }
    }
}