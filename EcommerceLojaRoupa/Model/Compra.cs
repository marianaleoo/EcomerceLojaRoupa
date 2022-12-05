using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Compra : EntidadeDominio
    {
        public string Status { get; set; }
        public int EnderecoEntregaId { get; set; }

        [ForeignKey("EnderecoEntregaId")]
        public EnderecoEntrega EnderecoEntrega { get; set; }
        public int CartaoCreditoId { get; set; }

        [ForeignKey("CartaoCreditoId")]
        public CartaoCredito CartaoCredito { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

         public List<ItemCompra> ItensCompra { get; set; }
        public int? CupomTrocaId { get; set; }

        public CupomTroca CupomTroca { get; set; }

        public double valorTotal { get; set; }


    }
}
