using System.Linq;
using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    internal abstract class Dao<T> : IDao<T>
        where T : class, IEntity
    {
        protected DaoContext Context { get; }

        protected Dao(DaoContext context)
        {
            Context = context;
        }

        public T Get(int id)
        {
            return Context.Set<T>().SingleOrDefault(e => e.Id == id);
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