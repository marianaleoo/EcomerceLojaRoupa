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
    public class ConsultaClienteAdminController : ControllerBase
    {
        private readonly CommandConsultar _commandConsultar;

        public ConsultaClienteAdminController(CommandConsultar commandConsultar)
        {
            _commandConsultar = commandConsultar;
        }


        [HttpGet()]
        public async Task<ActionResult<Cliente>> GetCliente(string nome, string cpf, string telefone)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.Telefone = telefone;
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
    }
}
