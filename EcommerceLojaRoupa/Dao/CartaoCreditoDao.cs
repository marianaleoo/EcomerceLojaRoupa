using EcommerceLojaRoupa.Dao;
using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaCartaoCredito.Dao
{
    public class CartaoCreditoDao : IDao
    {
        private readonly AppDbContext _context;

        public CartaoCreditoDao(AppDbContext context)
        {
            _context = context;
        }

        public CartaoCreditoDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            CartaoCredito CartaoCredito = (CartaoCredito)entidadeDominio;
            List<CartaoCredito> cartoesCredito = new List<CartaoCredito>();
            if (CartaoCredito.Id != 0)
            {
                List<EntidadeDominio> CartoesCredito = new List<EntidadeDominio>();
                CartoesCredito.Add(await ConsultarId(CartaoCredito.Id));
                return CartoesCredito;
            }
            if(CartaoCredito.ClienteId != 0)
            {
                List<CartaoCredito> cartoes = new List<CartaoCredito>();
                cartoesCredito = await _context.CartaoCredito.Include(c => c.Bandeira).ToListAsync();
                foreach (var item in cartoesCredito)
                {

                    if (item.ClienteId == CartaoCredito.ClienteId)
                    {
                        cartoes.Add(item);
                    }
                }

                return cartoes;
            }
            return await _context.CartaoCredito.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            CartaoCredito cartaoCredito = (CartaoCredito)entidadeDominio;
            cartaoCredito.Bandeira = await _context.Bandeira.FirstOrDefaultAsync(x => x.Id == cartaoCredito.BandeiraId);
            _context.CartaoCredito.Add(cartaoCredito);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            CartaoCredito CartaoCredito = (CartaoCredito)entidadeDominio;
            _context.Entry(CartaoCredito).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            CartaoCredito CartaoCredito = (CartaoCredito)entidadeDominio;

            var CartaoCreditoBanco = (CartaoCredito)await ConsultarId(CartaoCredito.Id);
            _context.CartaoCredito.Remove(CartaoCreditoBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.CartaoCredito.FindAsync(id);
            return entidadeDominio;
        }

        public Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int id, int clienteId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int clienteId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<EntidadeDominio>> ConsultarPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
