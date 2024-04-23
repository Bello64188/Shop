using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken, bool trackChanges = false);
        Task<IEnumerable<T>> GetAllWhere(CancellationToken cancellationToken, Expression<Func<T, bool>> expression, bool trackChanges = false);
        Task<T> GetById(Expression<Func<T, bool>> expression, bool trackChanges = false);
        Task Update(T entity, bool save = true);
        Task Add(T entity, bool save = true);
        Task AddRange(IEnumerable<T> entities, bool save = true);
        Task Remove(T entity, bool save = true);
        Task RemoveRange(IEnumerable<T> entities, bool save = true);
    }
}
