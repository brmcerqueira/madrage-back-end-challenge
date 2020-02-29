namespace MadrageBackEndChallenge.Persistence
{
    public interface IDao<T>
    {
        void Create(T entity);
        void Update(T entity);
    }
}