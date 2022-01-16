using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Precificacao : EntidadeDominio
    {
        public double Percentual { get; set; }
        public double PercentualMinimo { get; set; }
        public string Nome { get; set; }
    }
}
