using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class CidadeDao : IDao
    {
        private readonly AppDbContext _context;

        public CidadeDao(AppDbContext context)
        {
            _context = context;
        }

        public CidadeDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Cidade Cidade = (Cidade)entidadeDominio;
            if (Cidade.Id != 0)
            {
                List<EntidadeDominio> Cidades = new List<EntidadeDominio>();
                Cidades.Add(await ConsultarId(Cidade.Id));
                return Cidades;
            }
            return await _context.Cidade.Include(c => c.Estado.Pais).ToListAsync();
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Cidade.FindAsync(id);
            return entidadeDominio;
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Cidade cidade = (Cidade)entidadeDominio;
            _context.Cidade.Add(cidade);

            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Cidade cidade = (Cidade)entidadeDominio;
            _context.Entry(cidade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            Cidade cidade = (Cidade)entidadeDominio;

            var cidadeBanco = (Cidade)await ConsultarId(cidade.Id);
            _context.Cidade.Remove(cidadeBanco);
            await _context.SaveChangesAsync();

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
    }
}
