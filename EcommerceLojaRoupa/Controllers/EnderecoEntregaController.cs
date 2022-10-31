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
    public class EnderecoEntregaController : ControllerBase
    {

        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public EnderecoEntregaController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<EnderecoEntrega>>> Consultar()
        {
            EnderecoEntrega enderecoEntrega = new EnderecoEntrega();
            try
            {
                var enderecosEntrega = await _commandConsultar.Executar(enderecoEntrega);
                return Ok(enderecosEntrega);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Enderecos");
            }
        }

        [HttpGet("{clienteId}")]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>> GetEnderecoClienteId(int clienteId)
        {
            EnderecoEntrega enderecoEntrega = new EnderecoEntrega();
            enderecoEntrega.ClienteId = clienteId;
            try
            {

                var listaRetorno = await _commandConsultar.Executar(enderecoEntrega);

                return Ok(listaRetorno);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] EnderecoEntrega enderecoEntrega)
        {
            try
            {
                EnderecoEntrega enderecoEntregaID = new EnderecoEntrega();
                enderecoEntregaID.Id = id;
                await _commandAlterar.Executar(enderecoEntrega);
                return Ok($"Endereco entrega de id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            EnderecoEntrega enderecoEntrega = new EnderecoEntrega();
            enderecoEntrega.Id = id;
            try
            {
                await _commandExcluir.Executar(enderecoEntrega);
                return Ok($"Endereco entrega de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);


            }
        }
    }

}
