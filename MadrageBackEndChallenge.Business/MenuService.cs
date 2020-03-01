using System.Collections.Generic;
using System.Linq;
using MadrageBackEndChallenge.Business.Dtos;
using MadrageBackEndChallenge.Business.Validators;
using MadrageBackEndChallenge.Domain;
using MadrageBackEndChallenge.Domain.Exceptions;
using MadrageBackEndChallenge.Persistence.Daos;

namespace MadrageBackEndChallenge.Business
{
    internal class MenuService : ICrudService<IMenuSaveDto>
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
            var result = new List<Menu>
            {
                _dao.Get(id)
            };
            
            result.AddRange(_dao.GetSubmenus(id));

            return result.BuildMenuTreeNode().FirstOrDefault();
        }

        public void Save(IMenuSaveDto dto)
        {
            _menuSaveDtoValidator.Check(dto);
            
            if (dto.ParentId.HasValue && !_dao.HasParent(dto.ParentId.Value))
            {
                throw new ParentNotFoundException();
            }
            
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