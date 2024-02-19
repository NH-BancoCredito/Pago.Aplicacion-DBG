using AutoMapper;
using Models = Pago.Domain.Models;

namespace Pago.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public class RegistrarPagoMapper : Profile
    {
        public RegistrarPagoMapper()
        {
            CreateMap<RegistrarPagoRequest, Models.Pago>();
        }
    }
}
