using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    internal class MenuDao : Dao<Menu>
    {
        public MenuDao(DaoContext context) : base(context)
        {

        }
    }
}