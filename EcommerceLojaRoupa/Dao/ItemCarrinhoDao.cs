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
                List<EntidadeDominio> itemCarrinhos = new List<EntidadeDominio>();
                itemCarrinhos.Add(await ConsultarId(itemCarrinho.Id));
                return itemCarrinhos;
            }
            return  _context.ItemCarrinho;

        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            ItemCarrinho itemCarrinho = (ItemCarrinho)entidadeDominio;
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

            var itemCarrinhoBanco = (ItemCarrinho)await ConsultarId(itemCarrinho.Id);
            _context.ItemCarrinho.Remove(itemCarrinhoBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.ItemCarrinho.FindAsync(id);
            return entidadeDominio;
        }

        public Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            throw new NotImplementedException();
        }
    }
}
