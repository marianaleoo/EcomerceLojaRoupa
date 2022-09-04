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
    public class GeneroController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public GeneroController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Genero>>> Consultar()
        {
            Genero genero = new Genero();
            try
            {
                var generos = await _commandConsultar.Executar(genero);
                return Ok(generos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Generos");
            }
        }

        [HttpGet("{id:int}", Name = "GetGeneroId")]
        public async Task<ActionResult<Genero>> GetGeneroId(int id)
        {
            Genero genero = new Genero();
            genero.Id = id;
            try
            {
                var listaRetorno = (IEnumerable<EntidadeDominio>)
                await _commandConsultar.Executar(genero);
                if (listaRetorno.Count() <= 0)
                {
                    return NotFound($"Não existe Genero com id={id}");
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
        public async Task<ActionResult> Salvar(Genero Genero)
        {
            try
            {
                await _commandSalvar.Executar(Genero);
                return Ok(Genero);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Genero Genero)
        {
            try
            {
                Genero GeneroID = new Genero();
                GeneroID.Id = id;
                await _commandAlterar.Executar(Genero);
                return Ok($"Genero com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            Genero Genero = new Genero();
            Genero.Id = id;
            try
            {
                await _commandExcluir.Executar(Genero);
                return Ok($"Genero de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}
