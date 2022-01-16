using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class RoupaDao : IDao
    {
        private readonly AppDbContext _context;

        public RoupaDao(AppDbContext context)
        {
            _context = context;
        }

        public RoupaDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Roupa roupa = (Roupa)entidadeDominio;
            if (roupa.Id != 0)
            {
                List<EntidadeDominio> roupas = new List<EntidadeDominio>();
                roupas.Add(await ConsultarId(roupa.Id));
                return roupas;
            }
            return await _context.Roupa.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Roupa roupa = (Roupa)entidadeDominio;
            _context.Roupa.Add(roupa);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Roupa roupa = (Roupa)entidadeDominio;
            _context.Entry(roupa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            Roupa roupa = (Roupa)entidadeDominio;

            var roupaBanco = (Roupa)await ConsultarId(roupa.Id);
            _context.Roupa.Remove(roupaBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Roupa.FindAsync(id);
            return entidadeDominio;
        }
    }
}
