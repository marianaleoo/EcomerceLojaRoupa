using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class CompraDao : IDao
    {
        private readonly AppDbContext _context;

        public CompraDao(AppDbContext context)
        {
            _context = context;
        }

        public CompraDao()
        {
        }
        public Task Alterar(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
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
            Compra compra = (Compra)entidadeDominio;
            compra.Pedido = await _context.Pedido.FirstOrDefaultAsync(p => p.Id == compra.PedidoId);
            compra.EnderecoEntrega = await _context.EnderecoEntrega.FirstOrDefaultAsync(e => e.Id == compra.EnderecoEntregaId);
            compra.CartaoCredito = await _context.CartaoCredito.FirstOrDefaultAsync(e => e.Id == compra.CartaoCreditoId);
            _context.Compra.Add(compra);
            await _context.SaveChangesAsync();        
        }
    }
}
