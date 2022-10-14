using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class ItemCarrinho : EntidadeDominio
    {
        public int Quantidade { get; set; }
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [ForeignKey("RoupaId")]
        public int RoupaId { get; set; }
        public Roupa Roupa { get; set; }
        [ForeignKey("CarrinhoCompraId")]
        public int CarrinhoCompraId { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }



    }
}
