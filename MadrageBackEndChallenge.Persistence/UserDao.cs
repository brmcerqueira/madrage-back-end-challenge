using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence
{
    internal class UserDao : Dao<User>
    {
        public UserDao(DaoContext context) : base(context)
        {

        }
    }
}