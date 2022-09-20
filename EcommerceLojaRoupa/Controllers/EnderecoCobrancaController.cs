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
    public class EnderecoCobrancaController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public EnderecoCobrancaController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<EnderecoCobranca>>> Consultar()
        {
            EnderecoCobranca enderecoCobranca = new EnderecoCobranca();
            try
            {
                var enderecosCobranca = await _commandConsultar.Executar(enderecoCobranca);
                return Ok(enderecosCobranca);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Enderecos");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] EnderecoCobranca enderecoCobranca)
        {
            try
            {
                EnderecoCobranca enderecoCobrancaID = new EnderecoCobranca();
                enderecoCobrancaID.Id = id;
                await _commandAlterar.Executar(enderecoCobranca);
                return Ok($"Endereco cobrança de id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            EnderecoCobranca enderecoCobranca = new EnderecoCobranca();
            enderecoCobranca.Id = id;
            try
            {
                await _commandExcluir.Executar(enderecoCobranca);
                return Ok($"Endereco cobrança de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }

    }
}
