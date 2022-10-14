using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class CarrinhoCompraDao : IDao
    {
        private readonly AppDbContext _context;

        public CarrinhoCompraDao(AppDbContext context)
        {
            _context = context;
        }

        public CarrinhoCompraDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            CarrinhoCompra carrinhoCompra = (CarrinhoCompra)entidadeDominio;
            if (carrinhoCompra.Id != 0 && carrinhoCompra.ClienteId == 5)
            {
                List<EntidadeDominio> carrinhoCompras = new List<EntidadeDominio>();
                carrinhoCompras.Add(await ConsultarId(carrinhoCompra.Id));
                return carrinhoCompras;
            }
            return await _context.CarrinhoCompra.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            CarrinhoCompra carrinhoCompra = (CarrinhoCompra)entidadeDominio;
            _context.CarrinhoCompra.Add(carrinhoCompra);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            CarrinhoCompra carrinhoCompra = (CarrinhoCompra)entidadeDominio;
            _context.Entry(carrinhoCompra).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            CarrinhoCompra carrinhoCompra = (CarrinhoCompra)entidadeDominio;

            var carrinhoCompraBanco = (CarrinhoCompra)await ConsultarId(carrinhoCompra.Id);
            _context.CarrinhoCompra.Remove(carrinhoCompraBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.CarrinhoCompra.FindAsync(id);
            return entidadeDominio;
        }

        public async Task<EntidadeDominio> ConsultarCarrinhoCliente(int id, int clienteId)
        {
            var entidadeDominio = await _context.CarrinhoCompra.FindAsync(id, clienteId);
            return entidadeDominio;
        }
    }
}
