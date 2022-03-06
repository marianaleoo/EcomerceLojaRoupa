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

        public Task Salvar(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public Task Alterar(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public Task Excluir(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }
    }
}
