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

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Pedido pedido = (Pedido)entidadeDominio;
            if (pedido.ClienteId != 0)
            {
                List<Pedido> pedidos = new List<Pedido>();
                pedidos.Add(await _context.Pedido.FirstOrDefaultAsync(i => i.ClienteId == pedido.ClienteId));
                foreach (var item in pedidos)
                {
                    ItemCarrinho itemCarrinho;
                    itemCarrinho = await _context.ItemCarrinho.FirstOrDefaultAsync(i => i.Id == item.ItemCarrinhoId);
                    Roupa roupa;
                    roupa = await _context.Roupa.FirstOrDefaultAsync(r => r.Id == itemCarrinho.RoupaId);
                    itemCarrinho.Roupa = roupa;
                    item.ItemCarrinho = itemCarrinho;
                }
                return pedidos;
            }
            return await _context.Pedido.ToListAsync();
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
