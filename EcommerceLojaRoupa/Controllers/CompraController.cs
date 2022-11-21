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
    public class CompraController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;

        public CompraController(CommandSalvar commandSalvar)
        {
            _commandSalvar = commandSalvar;
        }
        [HttpPost]
        public async Task<ActionResult> Salvar(Compra compra)
        {
            try
            {
                await _commandSalvar.Executar(compra);
                return Ok(compra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
