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
    public class TipoTelefoneController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public TipoTelefoneController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<TipoTelefone>>> Consultar()
        {
            TipoTelefone tipoTelefone = new TipoTelefone();
            try
            {
                var tipoTelefones = await _commandConsultar.Executar(tipoTelefone);
                return Ok(tipoTelefones);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter TipoTelefones");
            }
        }

        [HttpGet("{id:int}", Name = "GetTipoTelefoneId")]
        public async Task<ActionResult<TipoTelefone>> GetTipoTelefoneId(int id)
        {
            TipoTelefone tipoTelefone = new TipoTelefone();
            tipoTelefone.Id = id;
            try
            {
                var listaRetorno = (IEnumerable<EntidadeDominio>)
                await _commandConsultar.Executar(tipoTelefone);
                if (listaRetorno.Count() <= 0)
                {
                    return NotFound($"Não existe TipoTelefone com id={id}");
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
        public async Task<ActionResult> Salvar(TipoTelefone tipoTelefone)
        {
            try
            {
                await _commandSalvar.Executar(tipoTelefone);
                return Ok(tipoTelefone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] TipoTelefone tipoTelefone)
        {
            try
            {
                TipoTelefone tipoTelefoneID = new TipoTelefone();
                tipoTelefoneID.Id = id;
                await _commandAlterar.Executar(tipoTelefone);
                return Ok($"TipoTelefone com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            TipoTelefone tipoTelefone = new TipoTelefone();
            tipoTelefone.Id = id;
            try
            {
                await _commandExcluir.Executar(tipoTelefone);
                return Ok($"TipoTelefone de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}
