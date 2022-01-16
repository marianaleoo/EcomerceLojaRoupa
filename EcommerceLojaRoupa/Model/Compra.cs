using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Compra : EntidadeDominio
    {
        public double Frete { get; set; }
        public double ValorVenda { get; set; }
    }
}
