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
    public class EnderecoController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public EnderecoController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Endereco>>> Consultar()
        {
            Endereco Endereco = new Endereco();
            try
            {
                var Enderecos = await _commandConsultar.Executar(Endereco);
                return Ok(Enderecos);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Enderecos");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Endereco endereco)
        {
            try
            {
                Endereco enderecoID = new Endereco();
                enderecoID.Id = id;
                await _commandAlterar.Executar(endereco);
                return Ok($"Endereco com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            Endereco endereco = new Endereco();
            endereco.Id = id;
            try
            {
                await _commandExcluir.Executar(endereco);
                return Ok($"Endereco de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }

    }
}
