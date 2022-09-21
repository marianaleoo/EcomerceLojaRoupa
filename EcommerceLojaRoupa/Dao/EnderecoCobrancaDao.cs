using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class EnderecoCobrancaDao : IDao
    {
        private readonly AppDbContext _context;

        public EnderecoCobrancaDao(AppDbContext context)
        {
            _context = context;
        }

        public EnderecoCobrancaDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            EnderecoCobranca enderecoCobranca = (EnderecoCobranca)entidadeDominio;
            if (enderecoCobranca.Id != 0)
            {
                List<EntidadeDominio> enderecosCobranca = new List<EntidadeDominio>();
                enderecosCobranca.Add(await ConsultarId(enderecoCobranca.Id));
                return enderecosCobranca;
            }
            return await _context.EnderecoCobranca.Include(c => c.Cidade.Estado.Pais).ToListAsync();
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.EnderecoCobranca.FindAsync(id);
            return entidadeDominio;
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            EnderecoCobranca enderecoCobranca = (EnderecoCobranca)entidadeDominio;
            _context.EnderecoCobranca.Add(enderecoCobranca);

            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            EnderecoCobranca enderecoCobranca = (EnderecoCobranca)entidadeDominio;
            _context.Entry(enderecoCobranca).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            EnderecoCobranca enderecoCobranca = (EnderecoCobranca)entidadeDominio;

            var enderecoCobrancaBanco = (EnderecoCobranca)await ConsultarId(enderecoCobranca.Id);
            _context.EnderecoCobranca.Remove(enderecoCobrancaBanco);
            await _context.SaveChangesAsync();

        }

        public Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            throw new System.NotImplementedException();
        }
    }
}
