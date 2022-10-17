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
    public class RoupaController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public RoupaController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Roupa>>> Consultar()
        {
            Roupa roupa = new Roupa();
            try
            {
                var roupas = await _commandConsultar.Executar(roupa);
                return Ok(roupas);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter roupas");
            }
        }

        [HttpGet("{id:int}", Name = "GetRoupaId")]
        public async Task<ActionResult<IAsyncEnumerable<Roupa>>> GetRoupaId(int id)
        {
            Roupa roupa = new Roupa();
            roupa.Id = id;
            try
            {
                var roupas = await _commandConsultar.Executar(roupa);
                return Ok(roupas);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter roupas");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(Roupa roupa)
        {
            try
            {
                await _commandSalvar.Executar(roupa);
                return Ok(roupa);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Roupa roupa)
        {
            try
            {
                Roupa roupaID = new Roupa();
                roupaID.Id = id;
                await _commandAlterar.Executar(roupa);
                return Ok($"Roupa com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            Roupa roupa = new Roupa();
            roupa.Id = id;
            try
            {
                await _commandExcluir.Executar(roupa);
                return Ok($"Roupa de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}

