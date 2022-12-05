using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class CupomTrocaDao : IDao
    {
        private readonly AppDbContext _context;

        public CupomTrocaDao(AppDbContext context)
        {
            _context = context;
        }

        public CupomTrocaDao()
        {
        }
        public Task Alterar(EntidadeDominio entidadeDominio)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            CupomTroca cupom = (CupomTroca)entidadeDominio;
            if (cupom.codigo != null)
            {
                return await _context.CupomTroca.Where(i => i.codigo == cupom.codigo).ToListAsync();

            }

            return await _context.CupomTroca.ToListAsync();
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
