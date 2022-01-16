using EcommerceLojaRoupa.Facade;
using EcommerceLojaRoupa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Command
{
    public class CommandAlterar : ICommand
    {
        private readonly IFachada _fachada;

        public CommandAlterar(IFachada fachada)
        {
            _fachada = fachada;
        }

        public async Task<Object> Executar(EntidadeDominio entidadeDominio)
        {
            return await _fachada.Alterar(entidadeDominio);
        }
    }
}
