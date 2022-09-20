using EcommerceLojaRoupa.Command;
using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaClienteAdminController : ControllerBase
    {
        private readonly CommandConsultar _commandConsultar;

        public ConsultaClienteAdminController(CommandConsultar commandConsultar)
        {
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>> Consultar()
        {
            Cliente cliente = new Cliente();
            try
            {
                var clientes = await _commandConsultar.Executar(cliente);
                return Ok(clientes);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter clientes");
            }
        }
    }
}
