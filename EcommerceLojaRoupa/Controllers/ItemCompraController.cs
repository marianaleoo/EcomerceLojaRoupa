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


    public class ItemCompraController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public ItemCompraController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet("{status}")]
        public async Task<ActionResult<IAsyncEnumerable<ItemCompra>>> ConsultarStatus(string status)
        {
            ItemCompra itemCompra = new ItemCompra();
            itemCompra.Status = status;
            try
            {
                var itensCompra = await _commandConsultar.Executar(itemCompra);
                return Ok(itensCompra);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Alterar(int id)
        {
            ItemCompra itemCompra = new ItemCompra();
            itemCompra.Id = id;

            try
            {
                var compraAlterada = await _commandAlterar.Executar(itemCompra);
                return Ok(compraAlterada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AceitarTroca")]
        public async Task<ActionResult> AceitarTroca(ItemCompra itemCompra)
        {
            _ = new ItemCompra();
            ItemCompra item = itemCompra;

            try
            {
                var itemCompraAlterado = await _commandAlterar.Executar(item);
                return Ok(itemCompraAlterado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("RecusarTroca")]
        public async Task<ActionResult> RecusarTroca(ItemCompra itemCompra)
        {
            _ = new ItemCompra();
            ItemCompra item = itemCompra;

            try
            {
                var itemCompraAlterado = await _commandAlterar.Executar(item);
                return Ok(itemCompraAlterado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
