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

    public class CartaoCreditoController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public CartaoCreditoController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<CartaoCredito>>> Consultar()
        {
            CartaoCredito cartaoCredito = new CartaoCredito();
            try
            {
                var cartoesCredito = await _commandConsultar.Executar(cartaoCredito);
                return Ok(cartoesCredito);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter cartões de crédito");
            }
        }

        [HttpGet("{clienteId}")]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>> GetCartaoClienteId(int clienteId)
        {
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.ClienteId = clienteId;
            try
            {

                var listaRetorno = await _commandConsultar.Executar(cartaoCredito);

                return Ok(listaRetorno);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(CartaoCredito cartaoCredito)
        {
            try
            {
                await _commandSalvar.Executar(cartaoCredito);
                return Ok(cartaoCredito);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] CartaoCredito cartaoCredito)
        {
            try
            {
                CartaoCredito cartaoCreditoID = new CartaoCredito();
                cartaoCreditoID.Id = id;
                await _commandAlterar.Executar(cartaoCredito);
                return Ok($"Cartão de crédito com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.Id = id;
            try
            {
                await _commandExcluir.Executar(cartaoCredito);
                return Ok($"Cartão de crédito com id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}

