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
            return Context.Set<User>().SingleOrDefault(e => e.Email == email);
        }

        public bool HasEmail(string email)
        {
            return Context.Set<User>().Any(e => e.Email == email);
        }

        public Menu[] GetMenuTreeByUserId(int id)
        {
            return (from mus in Context.Set<MenuUser>()
                join men in Context.Set<Menu>() on mus.MenuId equals men.Id
                where mus.UserId == id
                select men).ToArray();
        }
    }
}