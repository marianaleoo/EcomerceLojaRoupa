using EcommerceLojaRoupa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public interface IDao
    {
        Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio);
        Task <EntidadeDominio> ConsultarId(int id);
        Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone);
        Task Salvar(EntidadeDominio entidadeDominio);
        Task Alterar(EntidadeDominio entidadeDominio);
        Task Excluir(EntidadeDominio entidadeDominio);


    }
}
