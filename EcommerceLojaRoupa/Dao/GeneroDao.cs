using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class GeneroDao : IDao
    {
        private readonly AppDbContext _context;

        public GeneroDao(AppDbContext context)
        {
            _context = context;
        }

        public GeneroDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Genero genero = (Genero)entidadeDominio;
            if (genero.Id != 0)
            {
                List<EntidadeDominio> Generos = new List<EntidadeDominio>();
                Generos.Add(await ConsultarId(genero.Id));
                return Generos;
            }
            return await _context.Genero.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Genero genero = (Genero)entidadeDominio;
            _context.Genero.Add(genero);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Genero genero = (Genero)entidadeDominio;
            _context.Entry(genero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            Genero genero = (Genero)entidadeDominio;

            var GeneroBanco = (Genero)await ConsultarId(genero.Id);
            _context.Genero.Remove(GeneroBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Genero.FindAsync(id);
            return entidadeDominio;
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

