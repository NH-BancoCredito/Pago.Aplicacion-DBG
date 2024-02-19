using MediatR;
using Pago.Application.Common;

namespace Pago.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public class RegistrarPagoRequest : IRequest<IResult>
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int FormaPago { get; set; }
        public string? NumeroTarjeta { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? CVV { get; set; }
        public string? NombreTitular { get; set; }
        public int? NumeroCuotas { get; set; }
    }
}
