using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class ItemCarrinho : EntidadeDominio
    {
        public int Quantidade { get; set; }
        public int RoupaId { get; set; }
        [ForeignKey("RoupaId")]
        public Roupa Roupa { get; set; }
 
    }
}
