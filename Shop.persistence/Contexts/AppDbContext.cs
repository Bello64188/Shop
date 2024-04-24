using Microsoft.EntityFrameworkCore;
using Shop.Domain.Common.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shop.persistence.Contexts
{
    public class AppDbContext : IdentityDbContext
    {
        public virtual DbSet<Product> Products { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
