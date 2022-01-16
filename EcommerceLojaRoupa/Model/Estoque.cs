using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Estoque : EntidadeDominio
    {
        public int Quantidade { get; set; }
        public double ValorCompra { get; set; }
    }
}
