using EcommerceLojaRoupa.Command;
using EcommerceLojaRoupa.Dao;
using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public ClienteController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>> Consultar()
        {
            Cliente cliente = new Cliente();
            try
            {
                var clientes = await _commandConsultar.Executar(cliente);
                return Ok(clientes);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter clientes");
            }
        }

        [HttpGet("{email}/{senha}")]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>> ConsultarUsuario(string email, string senha)
        {
            Cliente cliente = new Cliente();
            cliente.Usuario = new Usuario();
            cliente.Usuario.Email = email;
            cliente.Usuario.Senha = senha;
     
            try
            {
                var clientes = await _commandConsultar.Executar(cliente);
                return Ok(clientes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

  

        [HttpGet("{id:int}", Name = "GetClienteId")]
        public async Task<ActionResult<IAsyncEnumerable<Cliente>>> GetClienteId(int id)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            try
            {

                var listaRetorno = await _commandConsultar.Executar(cliente);
         
                    return Ok(listaRetorno);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Salvar(Cliente cliente)
        {
            try
            {
                await _commandSalvar.Executar(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Alterar(int id, [FromBody] Cliente cliente)
        {
            try
            {
                Cliente clienteID = new Cliente();
                clienteID.Id = id;
                await _commandAlterar.Executar(cliente);
                return Ok($"Cliente com id={id} foi atualizado com sucesso");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Excluir(int id)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            try
            {
                await _commandExcluir.Executar(cliente);
                return Ok($"Cliente de id={id} foi excluído com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);

            }

        }
    }
}
