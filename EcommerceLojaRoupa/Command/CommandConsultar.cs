using EcommerceLojaRoupa.Facade;
using EcommerceLojaRoupa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Command
{
    public class CommandConsultar : ICommand
    {
        private readonly IFachada _fachada;

        public CommandConsultar(IFachada fachada)
        {
            _fachada = fachada;
        }

        public async Task<Object> Executar(EntidadeDominio entidadeDominio)
        {
            return await _fachada.Consultar(entidadeDominio);
        }

        public async Task<Object> ExecutarCliente(string nome, string cpf, string telefone)
        {
            return await _fachada.ConsultarCliente(nome, cpf, telefone);
        }
    }
}
