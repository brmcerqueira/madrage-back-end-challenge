using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IMenuDao : IDao<Menu>
    {
        bool HasParent(int id);
        Menu[] GetSubmenus(int id);
    }
}