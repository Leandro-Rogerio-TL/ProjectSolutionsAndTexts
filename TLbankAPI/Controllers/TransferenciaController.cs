using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLbankServices.DTOs;
using TLbankServices.Interfaces;

namespace TLbankAPI.Controllers;

[ApiController]
[Route("[Controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _service;
        public TransferenciaController(ITransferenciaService service)
        {
            _service = service;
        }

        [HttpPost("transferir")]
        public async Task<IActionResult> Transferir([FromBody]CriarTransferenciaDTO transferencia)
        {
            await _service.Executar(transferencia);
            return Ok();
        }

    }

