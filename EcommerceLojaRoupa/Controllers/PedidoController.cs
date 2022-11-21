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
        private readonly CommandAlterar _commandAlterar;

        public PedidoController(CommandSalvar commandSalvar, CommandAlterar commandAlterar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
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


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Pedido pedido)
        {
            try
            {
                Pedido pedidoID = new Pedido();
                pedido.Id = id;
                await _commandAlterar.Executar(pedido);
                return Ok($"Pedido com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
