namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IDao<T>
    {
        void Create(T entity);
        void Update(T entity);
    }
}