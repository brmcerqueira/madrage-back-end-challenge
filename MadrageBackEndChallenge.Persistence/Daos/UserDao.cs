using System.Linq;
using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    internal class UserDao : Dao<User>, IUserDao
    {
        public UserDao(DaoContext context) : base(context)
        {

        }

        public User GetUserByEmail(string email)
        {
            return context.Set<User>().SingleOrDefault(e => e.Email == email);
        }
    }
}