using EcommerceLojaRoupa.Model;
using System.ComponentModel.DataAnnotations;

namespace EcommerceLojaRoupa.Strategy
{
    public class ValidadorDadosCliente : IStrategy
    {
        public string Processar(EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;

            //adicionar regra de negocio para telefone e senha
            var nome = cliente.Nome;
            var genero = cliente.GeneroId;
            var dataNascimento = cliente.DataNascimento;
            var email = cliente.Email;
            var vencimentoCartao = cliente.CartaoCredito.ValidadeCartao;

            if (nome == null || genero == null || dataNascimento == null || email == null)
            {
                return "Dados de cliente são de preenchimento obrigatório!";
            }
            else if(nome == " " ||  email == " ")
            {
                return "Dados de cliente são de preenchimento obrigatório!";
            }
            if (!(new EmailAddressAttribute().IsValid(email)))
            {
                return "Endereço de e-mail inválido!";
            }
            if(vencimentoCartao < System.DateTime.Now)
            {
                return "Cartão Vencido!";
            }

            return null;

        }
    }
}
