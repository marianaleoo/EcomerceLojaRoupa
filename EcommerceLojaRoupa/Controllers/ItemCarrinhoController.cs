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
    public class ItemCarrinhoController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public ItemCarrinhoController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<ItemCarrinho>>> Consultar()
        {
            ItemCarrinho itemCarrinho = new ItemCarrinho();
            try
            {
                var itensCarrinho = await _commandConsultar.Executar(itemCarrinho);
                return Ok(itensCarrinho);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter itemCarrinhos");
            }
        }

        [HttpGet("{id:int}", Name = "GetItemCarrinhoId")]
        public async Task<ActionResult<ItemCarrinho>> GetItemCarrinhoId(int id)
        {
            ItemCarrinho itemCarrinho = new ItemCarrinho();
            itemCarrinho.Id = id;
            try
            {
                var listaRetorno = (IEnumerable<EntidadeDominio>)
                await _commandConsultar.Executar(itemCarrinho);
                if (listaRetorno.Count() <= 0)
                {
                    return NotFound($"Não existe itemCarrinho com id={id}");
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
        public async Task<ActionResult> Salvar(ItemCarrinho itemCarrinho)
        {
         
            try
            {
                await _commandSalvar.Executar(itemCarrinho);
                return Ok(itemCarrinho);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] ItemCarrinho itemCarrinho)
        {
            try
            {
                ItemCarrinho itemCarrinhoID = new ItemCarrinho();
                itemCarrinhoID.Id = id;
                await _commandAlterar.Executar(itemCarrinho);
                return Ok($"ItemCarrinho com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            ItemCarrinho itemCarrinho = new ItemCarrinho();
            itemCarrinho.Id = id;
            try
            {
                await _commandExcluir.Executar(itemCarrinho);
                return Ok($"ItemCarrinho de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}

