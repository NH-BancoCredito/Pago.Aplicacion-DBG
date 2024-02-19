using Pago.Domain.Models;

namespace Pago.Domain.Repositories
{
    public interface IPagoRepository : IRepository
    {
        Task<bool> Registrar(Models.Pago pago);
    }
}
