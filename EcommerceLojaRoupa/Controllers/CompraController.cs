using EcommerceLojaRoupa.Command;
using EcommerceLojaRoupa.Dao;
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
    public class CompraController : ControllerBase
    {
        private readonly CommandSalvar _commandSalvar;
        private readonly CommandConsultar _commandConsultar;
        private readonly CompraDao _compraDao;

        public CompraController(CommandSalvar commandSalvar, CommandConsultar commandConsultar, AppDbContext appDbContext)
        {
            _commandSalvar = commandSalvar;
            _commandConsultar = commandConsultar;
            _compraDao = new CompraDao(appDbContext);
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Compra>>> Consultar()
        {
            Compra compra = new Compra();
            try
            {
                var compras = await _commandConsultar.Executar(compra);
                return Ok(compras);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{clienteId:int}")]
        public async Task<ActionResult<IAsyncEnumerable<Compra>>> Consultar(int clienteId)
        {
            Compra compra = new Compra();
            compra.ClienteId = clienteId;
            try
            {
                var itensCompra = await _commandConsultar.Executar(compra);
                return Ok(itensCompra);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter itens de compra");
            }
        }


        [HttpPost]
        public async Task<ActionResult> Salvar(Compra compra)
        {
            try
            {
                await _commandSalvar.Executar(compra);
                return Ok(compra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Troca")]
        public async Task<ActionResult> TrocarItem(ItemCompra itemCompra)
        {

            try
            {
                var itemTroca = await  _compraDao.RealizarTroca(itemCompra);
                return Ok(itemTroca);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
