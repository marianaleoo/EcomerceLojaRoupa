using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class ItemCarrinhoDao : IDao
    {
        private readonly AppDbContext _context;

        public ItemCarrinhoDao(AppDbContext context)
        {
            _context = context;
        }

        public ItemCarrinhoDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            ItemCarrinho itemCarrinho = (ItemCarrinho)entidadeDominio;
            if (itemCarrinho.Id != 0)
            {
                List<ItemCarrinho> itemCarrinhos = new List<ItemCarrinho>();
                itemCarrinhos.Add((ItemCarrinho)await ConsultarPorId(itemCarrinho.Id));
                foreach (var item in itemCarrinhos)
                {
                    Roupa roupa = (Roupa)entidadeDominio;
                    roupa.Id = 1;
                    if (item.RoupaId == roupa.Id)
                    {
                        List<Roupa> roupas = new List<Roupa>();
                        roupas.Add(await _context.Roupa.FirstOrDefaultAsync(i => i.Id == roupa.Id));
                        return roupas;
                    }

                }
                return itemCarrinhos;
            }
            return _context.ItemCarrinho;

        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            ItemCarrinho itemCarrinho = (ItemCarrinho)entidadeDominio;
            var cliente = _context.Cliente.FirstOrDefault(i => i.Id == itemCarrinho.ClienteId);
            itemCarrinho.CarrinhoCompraId = cliente.CarrinhoId;
            _context.ItemCarrinho.Add(itemCarrinho);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            ItemCarrinho itemCarrinho = (ItemCarrinho)entidadeDominio;
            _context.Entry(itemCarrinho).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            ItemCarrinho itemCarrinho = (ItemCarrinho)entidadeDominio;

            var itemCarrinhoBanco = (ItemCarrinho)await ConsultarPorId(itemCarrinho.Id);
            _context.ItemCarrinho.Remove(itemCarrinhoBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<EntidadeDominio>> ConsultarPorId(int id)
        {
            EntidadeDominio entidadeDominio = new EntidadeDominio();
            ItemCarrinho itemCarrinho = (ItemCarrinho)entidadeDominio;
            itemCarrinho.Id = id;
            if (itemCarrinho.Id != 0)
            {
                List<ItemCarrinho> itemCarrinhos = new List<ItemCarrinho>();
                itemCarrinhos.Add((ItemCarrinho)await _context.ItemCarrinho.FindAsync(itemCarrinho.Id));
                foreach (var item in itemCarrinhos)
                {
                    Roupa roupa = (Roupa)entidadeDominio;
                    roupa.Id = 1;
                    if (item.RoupaId == roupa.Id)
                    {
                        List<Roupa> roupas = new List<Roupa>();
                        roupas.Add(await _context.Roupa.FirstOrDefaultAsync(i => i.Id == roupa.Id));
                        return roupas;
                    }

                }
                //return itemCarrinhos;
            }
            return _context.ItemCarrinho;
        }

        public Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            throw new NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int id, int clienteId)
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
    }
}
