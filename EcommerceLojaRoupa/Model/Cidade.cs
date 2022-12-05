using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Cidade : EntidadeDominio
    {
        public string Descricao { get; set; }

        public int estadoId { get; set; }

        [ForeignKey("estadoId")]
        public Estado Estado { get; set; }

        public double Frete { get; set; }
    }
}
