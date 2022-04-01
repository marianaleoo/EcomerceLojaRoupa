using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class EstadoDao : IDao
    {
        private readonly AppDbContext _context;

        public EstadoDao(AppDbContext context)
        {
            _context = context;
        }

        public EstadoDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Estado Estado = (Estado)entidadeDominio;
            if (Estado.Id != 0)
            {
                List<EntidadeDominio> Estados = new List<EntidadeDominio>();
                Estados.Add(await ConsultarId(Estado.Id));
                return Estados;
            }
            return await _context.Estado.Include(c => c.Pais).ToListAsync();
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Estado.FindAsync(id);
            return entidadeDominio;
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Estado estado = (Estado)entidadeDominio;
            _context.Estado.Add(estado);

            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Estado estado = (Estado)entidadeDominio;
            _context.Entry(estado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            Estado estado = (Estado)entidadeDominio;

            var estadoBanco = (Estado)await ConsultarId(estado.Id);
            _context.Estado.Remove(estadoBanco);
            await _context.SaveChangesAsync();

        }
    }
}
