using MadrageBackEndChallenge.Domain.Exceptions;
using MadrageBackEndChallenge.Persistence.Daos;

namespace MadrageBackEndChallenge.Business
{
    internal class MenuUserService : IMenuUserService
    {
        private readonly IMenuUserDao _dao;

        public MenuUserService(IMenuUserDao dao)
        {
            _dao = dao;
        }
        
        private void CheckHas(int menuId, int userId)
        {
            if (!_dao.HasMenu(menuId))
            {
                throw new MenuNotFoundException();
            }
            
            if (!_dao.HasUser(userId))
            {
                throw new UserNotFoundException();
            }
        }
        
        public void Grant(int menuId, int userId)
        {
            if (_dao.HasGrant(menuId, userId))
            {
                throw new GrantAlreadyExistsException();
            }
            
            CheckHas(menuId, userId);
            
            _dao.Grant(menuId, userId);
        }

        public void Delete(int menuId, int userId)
        {
            CheckHas(menuId, userId);
            _dao.Delete(menuId, userId);
        }
    }
}