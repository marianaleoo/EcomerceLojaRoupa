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
    public class CidadeController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandAlterar _commandAlterar;
        private readonly CommandExcluir _commandExcluir;
        private readonly CommandConsultar _commandConsultar;

        public CidadeController(CommandSalvar commandSalvar, CommandAlterar commandAlterar, CommandExcluir commandExcluir, CommandConsultar commandConsultar)
        {
            _commandSalvar = commandSalvar;
            _commandAlterar = commandAlterar;
            _commandExcluir = commandExcluir;
            _commandConsultar = commandConsultar;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Cidade>>> Consultar()
        {
            Cidade Cidade = new Cidade();
            try
            {
                var Cidades = await _commandConsultar.Executar(Cidade);
                return Ok(Cidades);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Cidades");
            }
        }

    }
}
