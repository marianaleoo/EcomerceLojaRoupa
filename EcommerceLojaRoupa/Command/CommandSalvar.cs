using EcommerceLojaRoupa.Facade;
using EcommerceLojaRoupa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Command
{
    public class CommandSalvar : ICommand
    {
        private readonly IFachada _fachada;

        public CommandSalvar(IFachada fachada)
        {
            _fachada = fachada;
        }

        public async Task<Object> Executar(EntidadeDominio entidadeDominio)
        {
            return await  _fachada.Salvar(entidadeDominio);
        }
    }
}
