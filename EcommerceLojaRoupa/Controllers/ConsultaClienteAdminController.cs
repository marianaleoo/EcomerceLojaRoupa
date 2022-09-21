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


        [HttpGet("{nome:string, cpf:string, telefone:string }", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> GetCliente(string nome, string cpf, string telefone)
        {
            try
            {
                var listaRetorno = (IEnumerable<EntidadeDominio>)
                await _commandConsultar.ExecutarCliente(nome, cpf, telefone);
                if (listaRetorno.Count() <= 0)
                {
                    return NotFound($"Não existe cliente");
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
    }
}
