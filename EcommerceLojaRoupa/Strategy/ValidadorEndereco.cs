using EcommerceLojaRoupa.Model;

namespace EcommerceLojaRoupa.Strategy
{
    public class ValidadorEndereco : IStrategy
    {
        public string Processar(EntidadeDominio entidade)
        {

            Cliente cliente = (Cliente)entidade;
            var tipoEndereco = cliente.EnderecoCobranca.TipoEnderecoId;
            var tipoResidencia = cliente.EnderecoCobranca.TipoResidencia;
            var tipoLogradouto = cliente.EnderecoCobranca.TipoLogradouro;
            var logradouro = cliente.EnderecoCobranca.Logradouro;
            var numero = cliente.EnderecoCobranca.Numero;
            var bairro = cliente.EnderecoCobranca.Bairro;
            var cidade = cliente.EnderecoCobranca.cidadeId;
            var estado = cliente.EnderecoCobranca.Cidade.estadoId;
            var pais = cliente.EnderecoCobranca.Cidade.Estado.paisId;


            if (tipoResidencia == null || tipoLogradouto == null || logradouro == null || numero == null || bairro == null || cidade == null || estado == null || pais == null )
            {
                return " Os dados de endereço são de preenchimento obrigatório!";
            }
            else if (tipoResidencia.Trim().Equals("") || tipoLogradouto.Trim().Equals("") || logradouro.Trim().Equals("") || numero.Trim().Equals("") || bairro.Trim().Equals(""))
            {
                return "Os dados de endereço são de preenchimento obrigatório!";
            }
            if(tipoEndereco != 1 && tipoEndereco != 2) 
            {
                 return "Os dados de endereço são de preenchimento obrigatório!";
            }

            return null;

        }
    }
}
