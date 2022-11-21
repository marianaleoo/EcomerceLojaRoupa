using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Compra : EntidadeDominio
    {
        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }
        public string Status { get; set; }
        public bool CartaoCredito { get; set; }
        public bool CupomPromocional { get; set; }
        public int EnderecoEntregaId { get; set; }

        [ForeignKey("EnderecoEntregaId")]
        public EnderecoEntrega EnderecoEntrega { get; set; }

    }
}
