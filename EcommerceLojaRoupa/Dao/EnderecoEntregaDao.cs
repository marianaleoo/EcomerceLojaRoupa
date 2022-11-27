using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class EnderecoEntregaDao : IDao

    {
        private readonly AppDbContext _context;

        public EnderecoEntregaDao(AppDbContext context)
        {
            _context = context;
        }

        public EnderecoEntregaDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            EnderecoEntrega enderecoEntrega = (EnderecoEntrega)entidadeDominio;
            List<EnderecoEntrega> enderecosEntrega = new List<EnderecoEntrega>();

            if (enderecoEntrega.Id != 0)
            {
                List<EntidadeDominio> enderecos = new List<EntidadeDominio>();
                enderecos.Add(await ConsultarId(enderecoEntrega.Id));
                return enderecosEntrega;
            }
            if (enderecoEntrega.ClienteId != 0)
            {
                List<EnderecoEntrega> listaEnderecos = new List<EnderecoEntrega>();
                enderecosEntrega = await _context.EnderecoEntrega.Include(c => c.Cidade.Estado.Pais).ToListAsync();
                foreach(var item in enderecosEntrega)
                {

                    if(item.ClienteId == enderecoEntrega.ClienteId)
                    {
                        listaEnderecos.Add(enderecoEntrega);
                    }             
                }

                return listaEnderecos;


            }
            return await _context.EnderecoEntrega.Include(c => c.Cidade.Estado.Pais).ToListAsync();
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.EnderecoEntrega.FindAsync(id);
            return entidadeDominio;
        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            EnderecoEntrega enderecoEntrega = (EnderecoEntrega)entidadeDominio;
            enderecoEntrega.Cidade = await _context.Cidade.FirstOrDefaultAsync(x => x.Id == enderecoEntrega.cidadeId);
            enderecoEntrega.Cidade.Estado = await _context.Estado.FirstOrDefaultAsync(x => x.Id == enderecoEntrega.Cidade.estadoId);
            _context.EnderecoEntrega.Add(enderecoEntrega);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            EnderecoEntrega enderecoEntrega = (EnderecoEntrega)entidadeDominio;
            _context.Entry(enderecoEntrega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(EntidadeDominio entidadeDominio)
        {
            EnderecoEntrega enderecoEntrega = (EnderecoEntrega)entidadeDominio;

            var enderecoEntregaBanco = (EnderecoEntrega)await ConsultarId(enderecoEntrega.Id);
            _context.EnderecoEntrega.Remove(enderecoEntregaBanco);
            await _context.SaveChangesAsync();

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

        public Task<IEnumerable<EntidadeDominio>> ConsultarPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

