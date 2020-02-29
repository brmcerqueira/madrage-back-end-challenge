using System.Collections.Generic;
using System.Linq;
using MadrageBackEndChallenge.Domain;

namespace MadrageBackEndChallenge.Persistence.Daos
{
    public interface IDao<T>
        where T : class, IEntity
    {
        IQueryable<T> All(int? index, int? limit);
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}