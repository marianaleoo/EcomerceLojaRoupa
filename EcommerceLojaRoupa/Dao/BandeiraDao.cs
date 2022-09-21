using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class BandeiraDao : IDao
    {
        private readonly AppDbContext _context;

        public BandeiraDao(AppDbContext context)
        {
            _context = context;
        }

        public BandeiraDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Bandeira Bandeira = (Bandeira)entidadeDominio;
            if (Bandeira.Id != 0)
            {
                List<EntidadeDominio> Bandeiras = new List<EntidadeDominio>();
                Bandeiras.Add(await ConsultarId(Bandeira.Id));
                return Bandeiras;
            }
            return await _context.Bandeira.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Bandeira Bandeira = (Bandeira)entidadeDominio;
            _context.Bandeira.Add(Bandeira);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Bandeira Bandeira = (Bandeira)entidadeDominio;
            _context.Entry(Bandeira).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            Bandeira Bandeira = (Bandeira)entidadeDominio;

            var BandeiraBanco = (Bandeira)await ConsultarId(Bandeira.Id);
            _context.Bandeira.Remove(BandeiraBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Bandeira.FindAsync(id);
            return entidadeDominio;
        }

        public Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            throw new System.NotImplementedException();
        }
    }
}

