using EcommerceLojaRoupa.Dao;
using EcommerceLojaRoupa.Model;
using System;

namespace EcommerceLojaRoupa.Strategy
{
    public class ValidadorCpf : IStrategy
    {
        public string Processar(EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;

            var cpf = cliente.Cpf;

            if (cpf == "" || cpf == null || cpf.Length < 11)
            {
                return "CPF deve conter 11 digitos!";
            }

            return null;
        }
    }
}


