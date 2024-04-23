using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Repositories;
using Shop.persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity, bool save = true)
        {
            await _context.Set<T>().AddAsync(entity);
            if (save)
                await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<T> entities, bool save = true)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            if (save)
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllWhere(CancellationToken cancellationToken, Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            if (trackChanges == false)
                return await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync(cancellationToken);
            return await _context.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }
        public async Task<T> GetById(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            if (trackChanges == false)
                return await _context.Set<T>().AsNoTracking().FirstAsync(expression);
            return await _context.Set<T>().FirstAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken, bool trackChanges = false)
        {
            if (trackChanges == false)
                return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }


        public async Task Remove(T entity, bool save = true)
        {
            _context.Set<T>().Remove(entity);
            if (save)
                await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities, bool save = true)
        {
            _context.Set<T>().RemoveRange(entities);
            if (save)
                await _context.SaveChangesAsync();
        }

        public async Task Update(T entity, bool save = true)
        {
            _context.Set<T>().Update(entity);
            if (save)
                await _context.SaveChangesAsync();
        }
    }

}
