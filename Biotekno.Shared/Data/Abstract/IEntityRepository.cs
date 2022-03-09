using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biotekno.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeProperties);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeProperties);

        Task AddAsync(T entity);

        void SaveChanges();

    }
}
