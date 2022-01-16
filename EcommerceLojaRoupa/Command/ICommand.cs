using EcommerceLojaRoupa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Command
{
    public interface ICommand
    {
        Task<Object> Executar(EntidadeDominio entidadeDominio);

    }
}
