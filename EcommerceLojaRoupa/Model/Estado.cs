using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Estado : EntidadeDominio
    {
        public string Descricao { get; set; }
        public Pais Pais { get; set; }
    }
}
