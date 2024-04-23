using Shop.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
