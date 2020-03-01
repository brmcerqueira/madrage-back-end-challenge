using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    internal class MenuDao : Dao<Menu>, IMenuDao
    {
        public MenuDao(DaoContext context) : base(context)
        {

        }

        public Menu[] GetSubmenus(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}