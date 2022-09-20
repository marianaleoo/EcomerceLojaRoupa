using EcommerceLojaRoupa.Model;

namespace EcommerceLojaRoupa.Strategy
{
    public class ValidadorEndereco : IStrategy
    {
        public string Processar(EntidadeDominio entidade)
        {

            Cliente cliente = (Cliente)entidade;;
            var tipoResidencia = cliente.EnderecoCobranca.TipoResidencia;
            var tipoLogradouto = cliente.EnderecoCobranca.TipoLogradouro;
            var logradouro = cliente.EnderecoCobranca.Logradouro;
            var numero = cliente.EnderecoCobranca.Numero;
            var bairro = cliente.EnderecoCobranca.Bairro;
            var cidade = cliente.EnderecoCobranca.cidadeId;
            var estado = cliente.EnderecoCobranca.Cidade.estadoId;
            var pais = cliente.EnderecoCobranca.Cidade.Estado.paisId;
            var tipoResidenciaEntrega = cliente.EnderecoEntrega.TipoResidencia;
            var tipoLogradoutoEntrega = cliente.EnderecoEntrega.TipoLogradouro;
            var logradouroEntrega = cliente.EnderecoEntrega.Logradouro;
            var numeroEntrega = cliente.EnderecoEntrega.Numero;
            var bairroEntrega = cliente.EnderecoEntrega.Bairro;
            var cidadeEntrega = cliente.EnderecoEntrega.cidadeId;
            var estadoEntrega = cliente.EnderecoEntrega.Cidade.estadoId;
            var paisEntrega = cliente.EnderecoEntrega.Cidade.Estado.paisId;


            if (tipoResidencia == null || tipoResidenciaEntrega== null || tipoLogradoutoEntrega == null ||tipoLogradouto == null || logradouro == null || logradouroEntrega == null || numero == null || numeroEntrega == null || bairro == null || bairroEntrega == null || cidade == null || cidadeEntrega ==null || estado == null || estadoEntrega == null  || pais == null || paisEntrega == null)
            {
                return " Os dados de endereço são de preenchimento obrigatório!";
            }
            else if (tipoResidencia.Trim().Equals("") || tipoResidenciaEntrega.Trim().Equals("") || tipoLogradouto.Trim().Equals("") || tipoLogradoutoEntrega.Trim().Equals("") || logradouro.Trim().Equals("") || logradouroEntrega.Trim().Equals("") || numero.Trim().Equals("") || numeroEntrega.Trim().Equals("") || bairro.Trim().Equals("") || bairroEntrega.Trim().Equals(""))
            {
                return "Os dados de endereço são de preenchimento obrigatório!";
            }

            return null;

        }
    }
}
