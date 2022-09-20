using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceLojaRoupa.Model
{
    public class EnderecoEntrega : EntidadeDominio
    {
        public string TipoResidencia { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        public int ClienteId { get; set; }

        public int cidadeId { get; set; }

        [ForeignKey("cidadeId")]
        public Cidade Cidade { get; set; }
    }
}
