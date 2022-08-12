using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class EnderecoDao : IDao
    {
        private readonly AppDbContext _context;

        public EnderecoDao(AppDbContext context)
        {
            _context = context;
        }

        public EnderecoDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Endereco Endereco = (Endereco)entidadeDominio;
            if (Endereco.Id != 0)
            {
                List<EntidadeDominio> Enderecos = new List<EntidadeDominio>();
                Enderecos.Add(await ConsultarId(Endereco.Id));
                return Enderecos;
            }
            return await _context.Endereco.Include(c => c.Cidade.Estado.Pais).ToListAsync();
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Endereco.FindAsync(id);
            return entidadeDominio;
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Endereco endereco = (Endereco)entidadeDominio;
            _context.Endereco.Add(endereco);

            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Endereco endereco = (Endereco)entidadeDominio;
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            Endereco endereco = (Endereco)entidadeDominio;

            var enderecoBanco = (Endereco)await ConsultarId(endereco.Id);
            _context.Endereco.Remove(enderecoBanco);
            await _context.SaveChangesAsync();

        }
    }
}
