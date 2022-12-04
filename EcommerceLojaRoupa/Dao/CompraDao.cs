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

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Compra compra = (Compra)entidadeDominio;
            if(compra.ClienteId != 0)
            {
                return await _context.Compra.Include("ItensCompra.Roupa").Where(i => i.ClienteId == compra.ClienteId).ToListAsync();
            }

            return await _context.Compra.Include("ItensCompra").ToListAsync();
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
            List<ItemCompra> itensCompra = new List<ItemCompra>();
            compra.EnderecoEntrega = await _context.EnderecoEntrega.FirstOrDefaultAsync(e => e.Id == compra.EnderecoEntregaId);
            compra.CartaoCredito = await _context.CartaoCredito.FirstOrDefaultAsync(e => e.Id == compra.CartaoCreditoId);
            compra.DataCadastro = DateTime.Now;
            _context.Compra.Add(compra);
            await _context.SaveChangesAsync();
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == compra.ClienteId);
            var itensCarrinho = await _context.ItemCarrinho.Where(i => i.CarrinhoCompraId == cliente.CarrinhoId).Include(i => i.Roupa).ToListAsync();
         
            foreach (var item in itensCarrinho)
            {
                for (int i = 0; i < item.Quantidade; i++)
                {
                    ItemCompra itemCompra = new ItemCompra();
                    itemCompra.Preco = item.Roupa.Preco;
                    itemCompra.Status = null;
                    itemCompra.RoupaId = item.RoupaId;
                    itemCompra.CompraId = compra.Id;
                    itensCompra.Add(itemCompra);
                }          
            }
            _context.ItemCompra.AddRange(itensCompra);
            await _context.SaveChangesAsync();
            _context.ItemCarrinho.RemoveRange(itensCarrinho);
            await _context.SaveChangesAsync();
        }

        public async Task<EntidadeDominio> RealizarTroca(ItemCompra itemCompra)
        {
            CupomTroca cupomTroca = new CupomTroca();
            var itemTroca = await _context.ItemCompra.FirstOrDefaultAsync(i => i.Id == itemCompra.Id);
            itemTroca.Status = "PEDIDO DE TROCA";
            await _context.SaveChangesAsync();
            return itemTroca;


            //cupomTroca.valorTroca = itemTroca.preco;
            //Guid myuuid = Guid.NewGuid();
            //cupomTroca.codigo = myuuid.ToString();
            // _context.CupomTroca.Add(cupomTroca);
            //await _context.SaveChangesAsync();
            //itemTroca.CompraTrocaId = cupomTroca.Id;
            //await _context.SaveChangesAsync();


        }
    }
}
