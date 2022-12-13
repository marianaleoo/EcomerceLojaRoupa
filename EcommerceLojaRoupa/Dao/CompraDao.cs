using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Compra compra = (Compra)entidadeDominio;
            if (compra.Id != 0)
            {
                var compraBanco = await _context.Compra.FirstOrDefaultAsync(c => c.Id == compra.Id);
                if (compraBanco.Status == "EM_PROCESSAMENTO")
                {
                    compraBanco.Status = "PAGAMENTO_REALIZADO";
                    await _context.SaveChangesAsync();
                }
                else if (compraBanco.Status == "PAGAMENTO_REALIZADO")
                {
                    compraBanco.Status = "EM_TRANSPORTE";
                    await _context.SaveChangesAsync();
                }
                else if (compraBanco.Status == "EM_TRANSPORTE")
                {
                    compraBanco.Status = "ENTREGUE";
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Compra compra = (Compra)entidadeDominio;
            if (compra.ClienteId != 0)
            {
                return await _context.Compra.Include("ItensCompra.Roupa").Include("ItensCompra.CupomTroca").Where(i => i.ClienteId == compra.ClienteId).ToListAsync();
            }
            if (compra.Status != null)
            {
                return await _context.Compra.Include("ItensCompra").Where(i => i.Status == compra.Status).ToListAsync();

            }

            //var retornoQuery =
            //    from c in _context.Categoria
            //    join r in _context.Roupa on c.Id equals r.CategoriaId
            //    join ic in _context.ItemCompra on r.Id equals ic.RoupaId
            //    join cc in _context.Compra on ic.CompraId equals cc.Id
            //    group c by c.Descricao into categorias
            //    select new { cc. }


            //from p in context.ParentTable
            //join c in context.ChildTable on p.ParentId equals c.ChildParentId into j1
            //from j2 in j1.DefaultIfEmpty()
            //group j2 by p.ParentId into grouped
            //select new { ParentId = grouped.Key, Count = grouped.Count(t => t.ChildId != null) }

            //from p in context.ParentTable
            //join c in context.ChildTable on p.ParentId equals c.ChildParentId into joined
            //select new { ParentId = p.ParentId, Count = joined.Count() }


            //var categorias = _context.Categoria.ToList();
            //var itensCompra = _context.ItemCompra.ToList();
            //var compras = _context.Compra.ToList();
            //var roupas = _context.Roupa.ToList();


            //var retornoQuery =
            //  from c in categorias
            //  join r in roupas on c.Id equals r.CategoriaId
            //  join ic in itensCompra on r.Id equals ic.RoupaId
            //  join cc in compras on ic.CompraId equals cc.Id 
            //  group c by c.Descricao into categoriaGroup

            //var query = from c in _context.Categoria
            //            join r in _context.Roupa on  c.Id equals r.CategoriaId
            //            join ic in _context.ItemCompra on  r.Id equals ic.RoupaId
            //            join cc in _context.Compra on  ic.CompraId equals cc.Id
            //            group c by c.Descricao into categoriaGroup
            //            orderby cc.DataCadastro ascending
            //            select new { 
            //                    Descricao = categoriaGroup.Descricao,
            //                    DataVenda = cc.DataCadastro,
            //                    Quantidade = Count(categoriaGroup.Descricao)                         
            //            };

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
            compra.EnderecoEntrega.Cidade = await _context.Cidade.FirstOrDefaultAsync(c => c.Id == compra.EnderecoEntrega.cidadeId);
            compra.CartaoCredito = await _context.CartaoCredito.FirstOrDefaultAsync(e => e.Id == compra.CartaoCreditoId);
            compra.DataCadastro = DateTime.Now;
            compra.CupomTroca = await _context.CupomTroca.FirstOrDefaultAsync(e => e.Id == compra.CupomTrocaId);
            _context.Compra.Add(compra);
            await _context.SaveChangesAsync();
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Id == compra.ClienteId);
            var itensCarrinho = await _context.ItemCarrinho.Where(i => i.CarrinhoCompraId == cliente.CarrinhoId).Include(i => i.Roupa).ToListAsync();

            foreach (var item in itensCarrinho)
            {
                for (int i = 0; i < item.Quantidade; i++)
                {
                    compra.valorTotal += item.Roupa.Preco;
                    compra.valorTotal += compra.EnderecoEntrega.Cidade.Frete;
                    if (compra.CupomTroca != null)
                    {
                        if (compra.CupomTroca.ativo == false)
                        {
                            compra.valorTotal -= compra.CupomTroca.valorTroca;
                            compra.CupomTroca.ativo = true;
                        }
                    }
                    compra.valorTotal.ToString("F2", CultureInfo.InvariantCulture);
                    ItemCompra itemCompra = new ItemCompra();
                    itemCompra.Preco = item.Roupa.Preco;
                    itemCompra.Preco.ToString("F2", CultureInfo.InvariantCulture);
                    itemCompra.Status = null;
                    itemCompra.RoupaId = item.RoupaId;
                    itemCompra.CompraId = compra.Id;
                    itensCompra.Add(itemCompra);
                }


            }

            await _context.SaveChangesAsync();
            _context.ItemCompra.AddRange(itensCompra);
            await _context.SaveChangesAsync();
            _context.ItemCarrinho.RemoveRange(itensCarrinho);
            await _context.SaveChangesAsync();
        }

        public async Task<EntidadeDominio> RealizarTroca(ItemCompra itemCompra)
        {
            CupomTroca cupomTroca = new CupomTroca();
            var itemTroca = await _context.ItemCompra.FirstOrDefaultAsync(i => i.Id == itemCompra.Id);
            itemTroca.Status = "PEDIDO_DE_TROCA";
            await _context.SaveChangesAsync();
            return itemTroca;
        }
    }
}
