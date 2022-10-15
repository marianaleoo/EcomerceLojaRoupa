using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class TipoTelefoneDao : IDao
    {

        private readonly AppDbContext _context;

        public TipoTelefoneDao(AppDbContext context)
        {
            _context = context;
        }

        public TipoTelefoneDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            TipoTelefone tipoTelefone = (TipoTelefone)entidadeDominio;
            if (tipoTelefone.Id != 0)
            {
                List<EntidadeDominio> tipoTelefones = new List<EntidadeDominio>();
                tipoTelefones.Add(await ConsultarId(tipoTelefone.Id));
                return tipoTelefones;
            }
            return await _context.TipoTelefone.ToListAsync();
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            TipoTelefone tipoTelefone = (TipoTelefone)entidadeDominio;
            _context.TipoTelefone.Add(tipoTelefone);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            TipoTelefone tipoTelefone = (TipoTelefone)entidadeDominio;
            _context.Entry(tipoTelefone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            TipoTelefone tipoTelefone = (TipoTelefone)entidadeDominio;

            var tipoTelefoneBanco = (TipoTelefone)await ConsultarId(tipoTelefone.Id);
            _context.TipoTelefone.Remove(tipoTelefoneBanco);
            await _context.SaveChangesAsync();

        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.TipoTelefone.FindAsync(id);
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

