using AutoMapper;
using MediatR;
using Pago.Application.Common;
using Pago.Domain.Repositories;
using Models = Pago.Domain.Models;

namespace Pago.Application.CasosUso.AdministrarPagos.RegistrarPago
{
    public class RegistrarPagoHandler : IRequestHandler<RegistrarPagoRequest, IResult>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;

        public RegistrarPagoHandler(IPagoRepository pagoRepository, IMapper mapper)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(RegistrarPagoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IResult response = null;
                var pago = _mapper.Map<Models.Pago>(request);

                await _pagoRepository.Registrar(pago);
                response = new SuccessResult();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error al registrar el pago {ex.Message}");
            }
        }
    }
}
