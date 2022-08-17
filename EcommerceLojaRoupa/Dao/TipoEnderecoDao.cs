using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class TipoEnderecoDao : IDao
    {
        private readonly AppDbContext _context;

        public TipoEnderecoDao(AppDbContext context)
        {
            _context = context;
        }

        public TipoEnderecoDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            TipoEndereco TipoEndereco = (TipoEndereco)entidadeDominio;
            if (TipoEndereco.Id != 0)
            {
                List<EntidadeDominio> TipoEnderecos = new List<EntidadeDominio>();
                TipoEnderecos.Add(await ConsultarId(TipoEndereco.Id));
                return TipoEnderecos;
            }
            return await _context.TipoEndereco.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            TipoEndereco TipoEndereco = (TipoEndereco)entidadeDominio;
            _context.TipoEndereco.Add(TipoEndereco);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            TipoEndereco TipoEndereco = (TipoEndereco)entidadeDominio;
            _context.Entry(TipoEndereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            TipoEndereco TipoEndereco = (TipoEndereco)entidadeDominio;

            var TipoEnderecoBanco = (TipoEndereco)await ConsultarId(TipoEndereco.Id);
            _context.TipoEndereco.Remove(TipoEnderecoBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.TipoEndereco.FindAsync(id);
            return entidadeDominio;
        }
    }
}

