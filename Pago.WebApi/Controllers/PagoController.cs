using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pago.Application.CasosUso.AdministrarPagos.RegistrarPago;

namespace Pago.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarPagoRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
