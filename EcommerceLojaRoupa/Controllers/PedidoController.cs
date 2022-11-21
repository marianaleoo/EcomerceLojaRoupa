using EcommerceLojaRoupa.Command;
using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;

        public PedidoController(CommandSalvar commandSalvar)
        {
            _commandSalvar = commandSalvar;
        }
        [HttpPost]
        public async Task<ActionResult> Salvar(Pedido pedido)
        {
            try
            {
                await _commandSalvar.Executar(pedido);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
