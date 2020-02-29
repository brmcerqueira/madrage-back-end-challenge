namespace MadrageBackEndChallenge.Persistence
{
    internal abstract class Dao<T> : IDao<T>
    {
        protected readonly DaoContext context;

        protected Dao(DaoContext context)
        {
            this.context = context;
        }
        
        public void Create(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        
        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}