using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Roupa : EntidadeDominio
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Tecido { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string Tamanho { get; set; }
        public double Preco { get; set; }
        public string URL { get; set; }

    }
}
