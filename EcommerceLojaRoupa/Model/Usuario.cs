using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Usuario : EntidadeDominio
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
