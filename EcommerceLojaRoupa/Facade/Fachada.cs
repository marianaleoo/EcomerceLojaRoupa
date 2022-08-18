using EcommerceLojaCartaoCredito.Dao;
using EcommerceLojaRoupa.Dao;
using EcommerceLojaRoupa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Facade
{
    public class Fachada : IFachada
    {
        private Dictionary<String, IDao> daos;

        public Fachada(AppDbContext dbContext)
        {
            daos = new Dictionary<string, IDao>();
            daos["Cliente"] = new ClienteDao(dbContext);
            daos["Roupa"] = new RoupaDao(dbContext);
            daos["ItemCarrinho"] = new ItemCarrinhoDao(dbContext);
            daos["Cidade"] = new CidadeDao(dbContext);
            daos["Estado"] = new EstadoDao(dbContext);
            daos["Pais"] = new PaisDao(dbContext);
            daos["CartaoCredito"] = new CartaoCreditoDao(dbContext);
            daos["Endereco"] = new EnderecoDao(dbContext);
            daos["TipoEndereco"] = new TipoEnderecoDao(dbContext);
            daos["Bandeira"] = new BandeiraDao(dbContext);
            //daos = new Dictionary<string, IDao>();
            //daos["CarrinhoCompra"] = carrinhoCompraDao;
        }

        //private void DefinirDaos()
        //{
        //    daos = new Dictionary<string, IDao>();
        //    ClienteDao clienteDao = new ClienteDao();
        //    daos["Cliente"] = clienteDao;
        //}

        public async Task<EntidadeDominio> Alterar(EntidadeDominio entidadeDominio)
        {
            try
            {
                IDao dao = this.daos[entidadeDominio.GetType().Name];
                await dao.Alterar(entidadeDominio);
                return entidadeDominio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EntidadeDominio> Salvar(EntidadeDominio entidadeDominio)
        {
            try
            {
                IDao dao = this.daos[entidadeDominio.GetType().Name];
                await dao.Salvar(entidadeDominio);
                return entidadeDominio;          

            }
            catch(Exception ex)
            {
               throw ex;
            }
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            try
            {
                IDao dao = this.daos[entidadeDominio.GetType().Name];
                return await dao.Consultar(entidadeDominio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<EntidadeDominio> Excluir(EntidadeDominio entidadeDominio)
        {
            try
            {
                IDao dao = this.daos[entidadeDominio.GetType().Name];
                await dao.Excluir(entidadeDominio);
                return entidadeDominio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entidadeDominio;
        }
    }
}
