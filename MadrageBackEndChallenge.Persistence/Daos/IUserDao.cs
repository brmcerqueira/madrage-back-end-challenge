using System.Collections.Generic;
using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IUserDao : IDao<User>
    {
        User GetUserByEmail(string email);
        bool HasEmail(string email);
        Menu[] GetMenusByUserId(int id);
    }
}