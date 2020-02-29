using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence
{
    internal class MenuDao : Dao<Menu>
    {
        public MenuDao(DaoContext context) : base(context)
        {

        }
    }
}