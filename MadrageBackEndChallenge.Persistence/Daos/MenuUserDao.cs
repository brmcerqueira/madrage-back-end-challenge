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

        public void Grant(int menuId, int userId)
        {
            _context.Add(new MenuUser
            {
                MenuId = menuId,
                UserId = userId
            });
            _context.SaveChanges();
        }

        public void Delete(int menuId, int userId)
        {
            var entity = _context.Set<MenuUser>().SingleOrDefault(e =>  e.MenuId == menuId && e.UserId == userId);
            
            if (entity == null) 
            {
                throw new EntityNotFoundException();
            }
            
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}