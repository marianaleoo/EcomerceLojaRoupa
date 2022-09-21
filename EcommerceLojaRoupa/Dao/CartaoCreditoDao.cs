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
            if (CartaoCredito.Id != 0)
            {
                List<EntidadeDominio> CartoesCredito = new List<EntidadeDominio>();
                CartoesCredito.Add(await ConsultarId(CartaoCredito.Id));
                return CartoesCredito;
            }
            return await _context.CartaoCredito.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            CartaoCredito CartaoCredito = (CartaoCredito)entidadeDominio;
            _context.CartaoCredito.Add(CartaoCredito);
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
    }
}
