using EcommerceLojaRoupa.Model;
using System;

namespace EcommerceLojaRoupa.Strategy
{
    public interface IStrategy
    {
        string Processar(EntidadeDominio entidadeDominio);
    }
}
