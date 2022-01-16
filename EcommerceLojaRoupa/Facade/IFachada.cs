using EcommerceLojaRoupa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Facade
{
    public interface IFachada
    {
        Task<EntidadeDominio> Salvar(EntidadeDominio entidadeDominio);
        Task<EntidadeDominio> Alterar(EntidadeDominio entidadeDominio);
        Task<EntidadeDominio> Excluir(EntidadeDominio entidadeDominio);
        Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidade);

    }
}
