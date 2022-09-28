using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class CarrinhoCompra : EntidadeDominio
    {
        List<ItemCarrinho> ItemCarrinhos;

        public int ClienteId { get; set; }
    }
}
