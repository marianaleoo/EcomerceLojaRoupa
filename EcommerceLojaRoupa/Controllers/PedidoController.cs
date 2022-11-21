using EcommerceLojaRoupa.Command;
using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Http;
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
        private readonly CommandConsultar _commandConsultar; 

        public PedidoController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandConsultar = commandConsultar;
        }

        [HttpGet("{clienteId:int}")]
        public async Task<ActionResult<IAsyncEnumerable<Pedido>>> Consultar(int clienteId)
        {
            Pedido pedido = new Pedido();
            pedido.ClienteId = clienteId;
            try
            {
                var pedidos = await _commandConsultar.Executar(pedido);
                return Ok(pedidos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter pedidos");
            }
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
