using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Cidade : EntidadeDominio
    {
        public string Descricao { get; set; }
        public Estado Estado { get; set; }
    }
}
