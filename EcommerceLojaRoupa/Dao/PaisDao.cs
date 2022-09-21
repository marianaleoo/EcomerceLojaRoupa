using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class PaisDao : IDao
    {
        private readonly AppDbContext _context;

        public PaisDao(AppDbContext context)
        {
            _context = context;
        }

        public PaisDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Pais Pais = (Pais)entidadeDominio;
            if (Pais.Id != 0)
            {
                List<EntidadeDominio> Paiss = new List<EntidadeDominio>();
                Paiss.Add(await ConsultarId(Pais.Id));
                return Paiss;
            }
            return await _context.Pais.ToListAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Pais.FindAsync(id);
            return entidadeDominio;
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Pais pais = (Pais)entidadeDominio;
            _context.Pais.Add(pais);

            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Pais pais = (Pais)entidadeDominio;
            _context.Entry(pais).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            Pais pais = (Pais)entidadeDominio;

            var paisBanco = (Pais)await ConsultarId(pais.Id);
            _context.Pais.Remove(paisBanco);
            await _context.SaveChangesAsync();

        }

        public Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            throw new System.NotImplementedException();
        }
    }
}
