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
    public class BandeiraController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public BandeiraController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Bandeira>>> Consultar()
        {
            Bandeira Bandeira = new Bandeira();
            try
            {
                var Bandeiras = await _commandConsultar.Executar(Bandeira);
                return Ok(Bandeiras);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Bandeiras");
            }
        }

        [HttpGet("{id:int}", Name = "GetBandeiraId")]
        public async Task<ActionResult<Bandeira>> GetBandeiraId(int id)
        {
            Bandeira Bandeira = new Bandeira();
            Bandeira.Id = id;
            try
            {
                var listaRetorno = (IEnumerable<EntidadeDominio>)
                await _commandConsultar.Executar(Bandeira);
                if (listaRetorno.Count() <= 0)
                {
                    return NotFound($"Não existe Bandeira com id={id}");
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
        public async Task<ActionResult> Salvar(Bandeira Bandeira)
        {
            try
            {
                await _commandSalvar.Executar(Bandeira);
                return Ok(Bandeira);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Bandeira Bandeira)
        {
            try
            {
                Bandeira BandeiraID = new Bandeira();
                BandeiraID.Id = id;
                await _commandAlterar.Executar(Bandeira);
                return Ok($"Bandeira com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            Bandeira Bandeira = new Bandeira();
            Bandeira.Id = id;
            try
            {
                await _commandExcluir.Executar(Bandeira);
                return Ok($"Bandeira de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}

