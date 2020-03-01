using System.Linq;
using MadrageBackEndChallenge.Business.Dtos;
using MadrageBackEndChallenge.Business.Validators;
using MadrageBackEndChallenge.Domain;
using MadrageBackEndChallenge.Persistence.Daos;

namespace MadrageBackEndChallenge.Business
{
    public class MenuService : ICrudService<IMenuSaveDto>
    {
        private readonly IMenuDao _dao;
        private readonly MenuSaveDtoValidator _menuSaveDtoValidator;

        public MenuService(IMenuDao dao)
        {
            _dao = dao;
            _menuSaveDtoValidator = new MenuSaveDtoValidator();
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
            _menuSaveDtoValidator.Check(dto);
            
            if (dto.Id != null)
            {
                var menu = _dao.Get(dto.Id.Value);
                menu.Label = dto.Label;
                menu.ParentId = dto.ParentId;
                _dao.Update(menu);  
            }
            else
            {
                _dao.Create(new Menu
                {
                    Label = dto.Label,
                    ParentId = dto.ParentId
                });  
            }
        }

        public void Delete(int id)
        {
            _dao.Delete(id);
        }
    }
}