using Pago.Domain.Repositories;
using Pago.Infraestructure.Repositories.Base;

namespace Pago.Infraestructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly PagoDbContext _context;

        public PagoRepository(PagoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Registrar(Domain.Models.Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return pago.IdPago > 0;
        }
    }
}
