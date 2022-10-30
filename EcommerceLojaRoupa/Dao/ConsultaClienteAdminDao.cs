using EcommerceLojaRoupa.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class ConsultaClienteAdminDao : IDao
    {
        private readonly AppDbContext _context;

        public ConsultaClienteAdminDao(AppDbContext context)
        {
            _context = context;
        }

        public ConsultaClienteAdminDao()
        {
        }

        public Task Alterar(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            var entidadeDominio = new EntidadeDominio();
            if (nome == null || nome == "")
            {
                if(cpf == null || cpf == "")
                {
                    if(telefone == null || telefone == "")
                    {
                        return null;
                    }
                    else
                    {
                          entidadeDominio = _context.Cliente.Find(telefone);
                    }
                }
                else
                {
                     entidadeDominio = _context.Cliente.Find(cpf);
                }
            }
            else
            {
                 entidadeDominio = _context.Cliente.Find(nome);
               
            }

            return entidadeDominio;
        }

        public Task<EntidadeDominio> ConsultarId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Excluir(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public Task Salvar(EntidadeDominio entidadeDominio)
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
