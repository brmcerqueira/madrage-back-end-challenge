using System.Linq;
using MadrageBackEndChallenge.Domain;
using MadrageBackEndChallenge.Domain.Exceptions;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    internal class MenuUserDao : IMenuUserDao
    {
        private readonly DaoContext _context;

        public MenuUserDao(DaoContext context)
        {
            _context = context;
        }
        
        public bool HasMenu(int id)
        {
            return _context.Set<Menu>().Any(e => e.Id == id);
        }

        public bool HasUser(int id)
        {
            return _context.Set<User>().Any(e => e.Id == id);
        }

        public bool HasGrant(int menuId, int userId)
        {
            return _context.Set<MenuUser>().Any(e => e.MenuId == menuId && e.UserId == userId);
        }

        private void GrantRecursively(int menuId, int userId)
        {
            var menu = _context.Set<Menu>().SingleOrDefault(e => e.Id == menuId);

            if (menu?.ParentId == null || HasGrant(menu.ParentId.Value, userId)) return;
            
            _context.Add(new MenuUser
            {
                MenuId = menu.ParentId.Value,
                UserId = userId
            });
                
            GrantRecursively(menu.ParentId.Value, userId);
        }
        
        public void Grant(int menuId, int userId)
        {
            _context.Add(new MenuUser
            {
                MenuId = menuId,
                UserId = userId
            });

            GrantRecursively(menuId, userId);
            
            _context.SaveChanges();
        }

        private void DeleteRecursively(int menuId, int userId)
        {
            foreach (var menuUser in (from mus in _context.Set<MenuUser>()
                join men in _context.Set<Menu>() on mus.MenuId equals men.Id
                where mus.UserId == userId && men.ParentId.HasValue &&men.ParentId.Value == menuId
                select mus).ToArray())
            {
                _context.Remove(menuUser);
                DeleteRecursively(menuUser.MenuId, userId);
            }
        }

        public void Delete(int menuId, int userId)
        {
            var entity = _context.Set<MenuUser>().SingleOrDefault(e =>  e.MenuId == menuId && e.UserId == userId);
            
            if (entity == null) 
            {
                throw new EntityNotFoundException();
            }
            
            _context.Remove(entity);

            DeleteRecursively(menuId, userId);
            
            _context.SaveChanges();
        }
    }
}