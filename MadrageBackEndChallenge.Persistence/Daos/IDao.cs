using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IDao<T>
        where T : class, IEntity
    {
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
    }
}