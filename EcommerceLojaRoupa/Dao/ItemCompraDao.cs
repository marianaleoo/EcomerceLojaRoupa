using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class ItemCompraDao : IDao
    {
        private readonly AppDbContext _context;

        public ItemCompraDao(AppDbContext context)
        {
            _context = context;
        }

        public ItemCompraDao()
        {
        }
        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            ItemCompra itemCompra = (ItemCompra)entidadeDominio;
            if(itemCompra.AceitarTroca == true && itemCompra.Status == "PEDIDO_DE_TROCA")
            {
                itemCompra.Status = "TROCA_ACEITA";
                _context.Entry(itemCompra).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else if (itemCompra.RecusarTroca == true && itemCompra.Status == "PEDIDO_DE_TROCA")
            {
                itemCompra.Status = "TROCA_RECUSADA";
                _context.ItemCompra.Add(itemCompra);
                await _context.SaveChangesAsync();
            }
            else if (itemCompra.Id != 0)
            {
                var itemCompraBanco = await _context.ItemCompra.FirstOrDefaultAsync(c => c.Id == itemCompra.Id);
 
                if (itemCompraBanco.Status == "TROCA_ACEITA")
                {
                    itemCompraBanco.Status = "TROCA_RECEBIDA";
                    _context.Entry(itemCompraBanco).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    CupomTroca cupomTroca = new CupomTroca();
                    cupomTroca.valorTroca = itemCompraBanco.Preco;
                    Guid myuuid = Guid.NewGuid();
                    cupomTroca.codigo = myuuid.ToString();
                    _context.CupomTroca.Add(cupomTroca);
                    await _context.SaveChangesAsync();
                    itemCompraBanco.CupomTrocaId = cupomTroca.Id;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            ItemCompra itemCompra = (ItemCompra)entidadeDominio;
            if (itemCompra.Status != null)
            {
                return await _context.ItemCompra.Where(i => i.Status == itemCompra.Status).ToListAsync();

            }

            return await _context.ItemCompra.ToListAsync();
        }

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<EntidadeDominio> ConsultarId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntidadeDominio>> ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public Task Salvar(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }
    }
}
