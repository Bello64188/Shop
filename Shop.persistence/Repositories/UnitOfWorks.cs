using Shop.Application.Interfaces.Repositories;
using Shop.persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.persistence.Repositories
{
#nullable disable
    public class UnitOfWorks : IUnitOfWorks
    {
        protected AppDbContext _context { get; private set; }
        public UnitOfWorks(AppDbContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
        }
        public IProductRepository Product { get; set; }
        public void Dispose()
        {
            _context?.Dispose();
            _context = null;

        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
