using FluentValidation;
using System.Runtime.CompilerServices;

namespace Pago.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public class RegistrarPagoValidator : AbstractValidator<RegistrarPagoRequest>
    {
        public RegistrarPagoValidator()
        {
            RuleFor(item => item.IdVenta).GreaterThan(0).WithMessage("El codigo de la venta debe ser mayor a 0");
            RuleFor(item => item.FormaPago).Must(ValidatorFormaPago).WithMessage(item => $"Forma pago debe ser 1 o 2 o 3");
            RuleFor(item => item.FechaVencimiento).Must((item, fecha) => ValidatorFechaVencimiento(item.FormaPago, fecha));
            
        }
        
        private bool ValidatorFormaPago(int value)
        {
            return value == 1 || value == 2 || value == 3;
        }

        private bool ValidatorFechaVencimiento(int value, DateTime? fechaVencimiento = null)
        {
            if (value == 1 || value == 2)
            {
                return fechaVencimiento == default || fechaVencimiento != default(DateTime);
            }
            
            if (value == 3)
            {
                return fechaVencimiento == default(DateTime) || fechaVencimiento is null;
            }
            return true;
        }
    }
}
