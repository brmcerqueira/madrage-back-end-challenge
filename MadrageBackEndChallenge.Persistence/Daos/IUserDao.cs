using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IUserDao : IDao<User>
    {
        User GetUserByEmail(string email);
        bool HasEmail(string email);
    }
}