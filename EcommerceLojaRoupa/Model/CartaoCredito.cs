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
        public string CodigoSeguranca { get; set; }
        public DateTime ValidadeCartao { get; set; }
        public int BandeiraId { get; set; }
        [ForeignKey("BandeiraId")]
        public virtual Bandeira Bandeira    { get; set; }
        public int ClienteId { get; set; }

    }
}
