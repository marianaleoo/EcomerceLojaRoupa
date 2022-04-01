using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class CartaoCredito : EntidadeDominio
    {
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string BandeiraCartao { get; set; }
        public string codigoSeguranca { get; set; }
    }
}
