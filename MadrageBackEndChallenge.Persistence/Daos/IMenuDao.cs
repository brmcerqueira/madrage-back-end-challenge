using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IMenuDao : IDao<Menu>
    {
        Menu[] GetSubmenus(int id);
    }
}