using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class CartaoCredito : EntidadeDominio
    {
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }

        public int BandeiraCartaoId { get; set; }

        [ForeignKey("BandeiraCartaoId")]
        public Bandeira BandeiraCartao { get; set; }
        public string CodigoSeguranca { get; set; }

        public int ClienteId { get; set; }

        //[ForeignKey("ClienteId")]
        //public Cliente Cliente { get; set; }
    }
}
