using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class CarrinhoCompra : EntidadeDominio
    {
       public List<ItemCarrinho> ItensCarrinho { get; set; }

    }
}
