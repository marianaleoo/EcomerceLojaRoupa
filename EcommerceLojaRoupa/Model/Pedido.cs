using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Pedido : EntidadeDominio
    {
        public string Frete { get; set; }
        public string ValorTotalVenda { get; set; }
        public string Status { get; set; }
        public int ItemCarrinhoId { get; set; }
        [ForeignKey("ItemCarrinhoId")]
        public  ItemCarrinho ItemCarrinho { get; set; }
        public int ClienteId { get; set; }




    }
}
