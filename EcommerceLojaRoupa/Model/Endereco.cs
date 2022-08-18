using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Endereco : EntidadeDominio
    {
        public string TipoResidencia { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        public int cidadeId { get; set; }

        [ForeignKey("cidadeId")]
        public Cidade Cidade { get; set; }
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public int TipoEnderecoId { get; set; }

        [ForeignKey("TipoEnderecoId")]
        public TipoEndereco TipoEndereco { get; set; }
    }
}
