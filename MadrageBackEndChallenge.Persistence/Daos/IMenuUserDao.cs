namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IMenuUserDao
    {
        bool HasMenu(int id);
        bool HasUser(int id);
        bool HasGrant(int menuId, int userId);
        void Grant(int menuId, int userId);
        void Delete(int menuId, int userId);
    }
}