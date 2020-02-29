namespace MadrageBackEndChallenge.Persistence
{
    internal interface IDao<T>
    {
        void Create(T entity);
        void Update(T entity);
    }
}