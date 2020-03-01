namespace MadrageBackEndChallenge.Business
{
    public interface IMenuUserService
    {
        void Grant(int menuId, int userId);
        void Delete(int menuId, int userId);
    }
}