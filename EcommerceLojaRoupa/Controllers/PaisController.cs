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
    public class PaisController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public PaisController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Pais>>> Consultar()
        {
            Pais Pais = new Pais();
            try
            {
                var Paises = await _commandConsultar.Executar(Pais);
                return Ok(Paises);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Paises");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Pais pais)
        {
            try
            {
                Pais paisID = new Pais();
                paisID.Id = id;
                await _commandAlterar.Executar(pais);
                return Ok($"Pais com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            Pais pais = new Pais();
            pais.Id = id;
            try
            {
                await _commandExcluir.Executar(pais);
                return Ok($"Pais de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }

}
