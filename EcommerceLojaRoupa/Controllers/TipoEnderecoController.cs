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
    public class TipoEnderecoController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public TipoEnderecoController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TipoEndereco>>> Consultar()
        {
            TipoEndereco TipoEndereco = new TipoEndereco();
            try
            {
                var TipoEnderecos = await _commandConsultar.Executar(TipoEndereco);
                return Ok(TipoEnderecos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter TipoEnderecos");
            }
        }

        [HttpGet("{id:int}", Name = "GetTipoEnderecoId")]
        public async Task<ActionResult<TipoEndereco>> GetTipoEnderecoId(int id)
        {
            TipoEndereco TipoEndereco = new TipoEndereco();
            TipoEndereco.Id = id;
            try
            {
                var listaRetorno = (IEnumerable<EntidadeDominio>)
                await _commandConsultar.Executar(TipoEndereco);
                if (listaRetorno.Count() <= 0)
                {
                    return NotFound($"Não existe TipoEndereco com id={id}");
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
        public async Task<ActionResult> Salvar(TipoEndereco TipoEndereco)
        {
            try
            {
                await _commandSalvar.Executar(TipoEndereco);
                return Ok(TipoEndereco);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] TipoEndereco TipoEndereco)
        {
            try
            {
                TipoEndereco TipoEnderecoID = new TipoEndereco();
                TipoEnderecoID.Id = id;
                await _commandAlterar.Executar(TipoEndereco);
                return Ok($"TipoEndereco com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            TipoEndereco TipoEndereco = new TipoEndereco();
            TipoEndereco.Id = id;
            try
            {
                await _commandExcluir.Executar(TipoEndereco);
                return Ok($"TipoEndereco de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}

