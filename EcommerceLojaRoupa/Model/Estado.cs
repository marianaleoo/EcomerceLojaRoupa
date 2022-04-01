using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Estado : EntidadeDominio
    {
        public string Descricao { get; set; }

        public int paisId { get; set; }

        [ForeignKey("paisId")]
        public Pais Pais { get; set; }
    }
}
