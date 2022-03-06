using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class ClienteDao : IDao
    {
        private readonly AppDbContext _context;

        public ClienteDao(AppDbContext context)
        {
            _context = context;
        }

        public ClienteDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;
            if(cliente.Id != 0)
            {
                List<EntidadeDominio> clientes = new List<EntidadeDominio>();
                clientes.Add(await ConsultarId(cliente.Id));
                return clientes;
            }
            return await _context.Cliente.Include(c => c.EnderecoCobranca).ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;
            _context.Cliente.Add(cliente);

            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir (EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;

            var clienteBanco = (Cliente)await ConsultarId(cliente.Id);
            _context.Cliente.Remove(clienteBanco);
            await _context.SaveChangesAsync();
            
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Cliente.FindAsync(id);
            return entidadeDominio;
        }
    }
}
