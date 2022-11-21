using EcommerceLojaCartaoCredito.Dao;
using EcommerceLojaRoupa.Dao;
using EcommerceLojaRoupa.Model;
using EcommerceLojaRoupa.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Facade
{
    public class Fachada : IFachada
    {
        private Dictionary<String, IDao> daos;
        private Dictionary<String, List<IStrategy>> rNegocio;

        public Fachada(AppDbContext dbContext)
        {
            DefinirDaos(dbContext);
            DefinirNegocio(dbContext);
        }

        private void DefinirDaos(AppDbContext dbContext)
        {

            daos = new Dictionary<string, IDao>();
            daos["Cliente"] = new ClienteDao(dbContext);
            daos["Roupa"] = new RoupaDao(dbContext);
            daos["ItemCarrinho"] = new ItemCarrinhoDao(dbContext);
            daos["Cidade"] = new CidadeDao(dbContext);
            daos["Estado"] = new EstadoDao(dbContext);
            daos["Pais"] = new PaisDao(dbContext);
            daos["CartaoCredito"] = new CartaoCreditoDao(dbContext);
            daos["EnderecoCobranca"] = new EnderecoCobrancaDao(dbContext);
            daos["EnderecoEntrega"] = new EnderecoEntregaDao(dbContext);
            daos["Bandeira"] = new BandeiraDao(dbContext);
            daos["Genero"] = new GeneroDao(dbContext);
            daos["TipoTelefone"] = new TipoTelefoneDao(dbContext);
            daos["CarrinhoCompra"] = new CarrinhoCompraDao(dbContext);
            daos["Usuario"] = new UsuarioDao(dbContext);
            daos["Pedido"] = new PedidoDao(dbContext);
            daos["Compra"] = new CompraDao(dbContext);

        }

        private void DefinirNegocio(AppDbContext dbContext)
        {
            rNegocio = new Dictionary<string, List<IStrategy>>();
            List<IStrategy> rNegocioCliente = new List<IStrategy>();
            ValidadorCpf validCpf = new ValidadorCpf();
            rNegocioCliente.Add(validCpf);
            rNegocio["Cliente"] = rNegocioCliente;
            ValidadorDadosCliente validDadosCliente = new ValidadorDadosCliente();
            rNegocioCliente.Add(validDadosCliente);
            rNegocio["Cliente"] = rNegocioCliente;
            ValidadorEndereco validEndereco = new ValidadorEndereco();
            rNegocioCliente.Add(validEndereco);
            rNegocio["Cliente"] = rNegocioCliente;
        }

        public async Task<EntidadeDominio> Alterar(EntidadeDominio entidadeDominio)
        {
            if (rNegocio.ContainsKey(entidadeDominio.GetType().Name))
            {
                List<IStrategy> validacoes = this.rNegocio[entidadeDominio.GetType().Name];
                string resultado = "";
                foreach (var item in validacoes)
                {
                    resultado += item.Processar(entidadeDominio);
                }
                if (!string.IsNullOrEmpty(resultado))
                {
                    throw new Exception(resultado);
                }
            }
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
            if (rNegocio.ContainsKey(entidadeDominio.GetType().Name))
            {
                List<IStrategy> validacoes = this.rNegocio[entidadeDominio.GetType().Name];
                string resultado = "";
                foreach (var item in validacoes)
                {
                    resultado += item.Processar(entidadeDominio);
                }
                if (!string.IsNullOrEmpty(resultado))
                {
                    throw new Exception(resultado);
                }
            }
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
