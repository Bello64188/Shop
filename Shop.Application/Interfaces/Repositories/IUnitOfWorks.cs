using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Repositories
{
    public interface IUnitOfWorks : IDisposable
    {
        public IProductRepository Product { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
