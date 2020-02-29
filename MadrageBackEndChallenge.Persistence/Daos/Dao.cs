namespace MadrageBackEndChallenge.Persistence.Daos
{
    internal abstract class Dao<T> : IDao<T>
    {
        protected DaoContext Context { get; }

        protected Dao(DaoContext context)
        {
            Context = context;
        }
        
        public void Create(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
        
        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
    }
}