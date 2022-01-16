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
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public CarrinhoCompraController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<CarrinhoCompra>>> Consultar()
        {
            CarrinhoCompra carrinhoCompra = new CarrinhoCompra();
            try
            {
                var carrinhoCompras = await _commandConsultar.Executar(carrinhoCompra);
                return Ok(carrinhoCompras);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter carrinhoCompras");
            }
        }

        [HttpGet("{id:int}", Name = "GetCarrinhoCompraId")]
        public async Task<ActionResult<CarrinhoCompra>> GetCarrinhoCompraId(int id)
        {
            CarrinhoCompra carrinhoCompra = new CarrinhoCompra();
            carrinhoCompra.Id = id;
            try
            {
                var listaRetorno = (IEnumerable<EntidadeDominio>)
                await _commandConsultar.Executar(carrinhoCompra);
                if (listaRetorno.Count() <= 0)
                {
                    return NotFound($"Não existe carrinhoCompra com id={id}");
                }
                else
                {
                    return Ok(listaRetorno);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(CarrinhoCompra carrinhoCompra)
        {
            try
            {
                await _commandSalvar.Executar(carrinhoCompra);
                return Ok(carrinhoCompra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] CarrinhoCompra carrinhoCompra)
        {
            try
            {
                CarrinhoCompra carrinhoCompraID = new CarrinhoCompra();
                carrinhoCompraID.Id = id;
                await _commandAlterar.Executar(carrinhoCompra);
                return Ok($"CarrinhoCompra com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            CarrinhoCompra carrinhoCompra = new CarrinhoCompra();
            carrinhoCompra.Id = id;
            try
            {
                await _commandExcluir.Executar(carrinhoCompra);
                return Ok($"CarrinhoCompra de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}
