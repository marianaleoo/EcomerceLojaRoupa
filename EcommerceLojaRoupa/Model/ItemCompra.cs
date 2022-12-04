using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class ItemCompra : EntidadeDominio
    {
        public double Preco { set; get; }
        [ForeignKey("RoupaId")]
        public int RoupaId { get; set; }
        public Roupa Roupa { get; set; }
        public string Status { get; set; }
        public int CompraId { get; set; }

        [ForeignKey("CompraTrocaId")]
        public int CompraTrocaId { get; set; }
        public CupomTroca CupomTroca { get; set; }

    }
}
