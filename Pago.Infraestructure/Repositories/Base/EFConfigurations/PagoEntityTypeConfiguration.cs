using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models = Pago.Domain.Models;

namespace Pago.Infraestructure.Repositories.Base.EFConfigurations
{
    public class PagoEntityTypeConfiguration : IEntityTypeConfiguration<Models.Pago>
    {
        public void Configure(EntityTypeBuilder<Models.Pago> builder)
        {
            builder.ToTable("Pago");
            builder.HasKey(c => c.IdPago);
        }
    }
}
