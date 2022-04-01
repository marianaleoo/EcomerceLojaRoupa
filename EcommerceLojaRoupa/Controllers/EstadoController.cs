using EcommerceLojaRoupa.Command;
using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public EstadoController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Estado>>> Consultar()
        {
            Estado Estado = new Estado();
            try
            {
                var Estados = await _commandConsultar.Executar(Estado);
                return Ok(Estados);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Estados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Estado estado)
        {
            try
            {
                Estado estadoID = new Estado();
                estadoID.Id = id;
                await _commandAlterar.Executar(estado);
                return Ok($"Estado com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            Estado estado = new Estado();
            estado.Id = id;
            try
            {
                await _commandExcluir.Executar(estado);
                return Ok($"Estado de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}
