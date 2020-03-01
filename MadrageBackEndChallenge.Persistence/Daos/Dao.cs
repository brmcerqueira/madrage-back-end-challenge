using System.Linq;
using MadrageBackEndChallenge.Domain;
using MadrageBackEndChallenge.Domain.Exceptions;

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

        public IQueryable<T> All(int? index, int? limit)
        {
            IQueryable<T> query = Context.Set<T>();

            if (index.HasValue)
            {
                query = query.Skip(index.Value);
            }
            
            if (limit.HasValue)
            {
                query = query.Take(limit.Value);
            }
            
            return query;
        }

        public T Get(int id)
        {
            var entity = Context.Set<T>().SingleOrDefault(e => e.Id == id);
            
            if (entity == null) 
            {
                throw new EntityNotFoundException();
            }

            return entity;
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

        public void Delete(int id)
        {
            Context.Remove(Get(id));
            Context.SaveChanges();
        }
    }
}