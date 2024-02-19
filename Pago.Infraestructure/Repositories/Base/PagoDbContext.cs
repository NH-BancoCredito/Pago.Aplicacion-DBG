using Microsoft.EntityFrameworkCore;
using Models = Pago.Domain.Models;

namespace Pago.Infraestructure.Repositories.Base
{
    public class PagoDbContext : DbContext
    {
        public PagoDbContext(DbContextOptions<PagoDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Models.Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagoDbContext).Assembly);
        }

    }
}
