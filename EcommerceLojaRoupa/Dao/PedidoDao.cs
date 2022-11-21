using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class PedidoDao : IDao
    {
        private readonly AppDbContext _context;

        public PedidoDao(AppDbContext context)
        {
            _context = context;
        }

        public PedidoDao()
        {
        }
        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Pedido pedido = (Pedido)entidadeDominio;
            pedido.ItemCarrinho = await _context.ItemCarrinho.FirstOrDefaultAsync(p => p.Id == pedido.ItemCarrinhoId);
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntidadeDominio>> ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Pedido pedido = (Pedido)entidadeDominio;
            pedido.ItemCarrinho = await _context.ItemCarrinho.FirstOrDefaultAsync(x => x.Id == 1);
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
