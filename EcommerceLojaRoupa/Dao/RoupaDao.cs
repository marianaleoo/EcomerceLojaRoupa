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
                List<Roupa> roupas = new List<Roupa>();
                roupas.Add(await _context.Roupa.FirstOrDefaultAsync(i => i.Id == roupa.Id));
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
            throw new NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            throw new NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int id, int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
