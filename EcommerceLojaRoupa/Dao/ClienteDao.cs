using EcommerceLojaRoupa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class ClienteDao : IDao
    {
        private readonly AppDbContext _context;

        public ClienteDao(AppDbContext context)
        {
            _context = context;
        }

        public ClienteDao()
        {
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            
            Cliente cliente = (Cliente)entidadeDominio;
            if(cliente.Id != 0)
            {
                List<Cliente> clientes = new List<Cliente>();
                clientes.Add(await _context.Cliente.Include("Carrinho.ItensCarrinho.Roupa").FirstOrDefaultAsync(c => c.Id == cliente.Id));
                return clientes;
            }
            if(cliente.Usuario.Email != null)
            {
                List<EntidadeDominio> clientes = new List<EntidadeDominio>();
                clientes.Add(await ConsultarClientePorUsuario(cliente.Usuario.Email, cliente.Usuario.Senha));
                return clientes;
            }
            if (cliente.Nome != null)
            {
                await _context.Cliente.FirstOrDefaultAsync(c => c.Nome == cliente.Nome);
                await _context.Cliente.Include(c => c.EnderecoCobranca.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.Nome == cliente.Nome);
                await _context.Cliente.Include(c => c.EnderecoEntrega.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.Nome == cliente.Nome);
                await _context.Cliente.Include(c => c.CartaoCredito).FirstOrDefaultAsync(c => c.Nome == cliente.Nome);
                await _context.Cliente.Include(c => c.Genero).FirstOrDefaultAsync(c => c.Nome == cliente.Nome); 
                return _context.Cliente;
            }
            if (cliente.Cpf != null)
            {
                await _context.Cliente.FirstOrDefaultAsync(c => c.Cpf == cliente.Cpf);
                await _context.Cliente.Include(c => c.EnderecoCobranca.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.Cpf == cliente.Cpf);
                await _context.Cliente.Include(c => c.EnderecoEntrega.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.Cpf == cliente.Cpf);
                await _context.Cliente.Include(c => c.CartaoCredito).FirstOrDefaultAsync(c => c.Cpf == cliente.Cpf);
                await _context.Cliente.Include(c => c.Genero).FirstOrDefaultAsync(c => c.Cpf == cliente.Cpf);
                return _context.Cliente;
            }
            if (cliente.Telefone != null)
            {
                await _context.Cliente.FirstOrDefaultAsync(c => c.Telefone == cliente.Telefone);
                await _context.Cliente.Include(c => c.EnderecoCobranca.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.Telefone == cliente.Telefone);
                await _context.Cliente.Include(c => c.EnderecoEntrega.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.Telefone == cliente.Telefone);
                await _context.Cliente.Include(c => c.CartaoCredito).FirstOrDefaultAsync(c => c.Telefone == cliente.Telefone);
                await _context.Cliente.Include(c => c.Genero).FirstOrDefaultAsync(c => c.Telefone == cliente.Telefone);
                return _context.Cliente;
            }
     
            await _context.Cliente.Include(c => c.EnderecoCobranca.Cidade.Estado.Pais).ToListAsync();
            await _context.Cliente.Include(c => c.EnderecoEntrega.Cidade.Estado.Pais).ToListAsync();
            await _context.Cliente.Include(c => c.CartaoCredito).ToListAsync();
            await _context.Cliente.Include(c => c.Genero).ToListAsync();

            return  _context.Cliente;

        }

        public async Task Salvar(EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;
            Usuario usuario = new Usuario();
            usuario.Email = cliente.Email;
            usuario.Senha = cliente.Senha;
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            var usuarioBanco = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == usuario.Email);
            cliente.UsuarioId = usuarioBanco.Id;
            CarrinhoCompra carrinhoCompra = new CarrinhoCompra();
            carrinhoCompra.DataCadastro = DateTime.Now;
            _context.CarrinhoCompra.Add(carrinhoCompra);
            await _context.SaveChangesAsync();
            var carrinhoBanco = await _context.CarrinhoCompra.FirstOrDefaultAsync(c => c.DataCadastro == carrinhoCompra.DataCadastro);
            cliente.CarrinhoId = carrinhoBanco.Id;
            cliente.EnderecoCobranca.Cidade = await _context.Cidade.FirstOrDefaultAsync(x => x.Id == cliente.EnderecoCobranca.cidadeId);
            cliente.EnderecoCobranca.Cidade.Estado = await _context.Estado.FirstOrDefaultAsync(x => x.Id == cliente.EnderecoCobranca.Cidade.estadoId);
            cliente.EnderecoEntrega.Cidade = await _context.Cidade.FirstOrDefaultAsync(x => x.Id == cliente.EnderecoEntrega.cidadeId);
            cliente.EnderecoEntrega.Cidade.Estado = await _context.Estado.FirstOrDefaultAsync(x => x.Id == cliente.EnderecoEntrega.Cidade.estadoId);
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;
            _context.Entry(cliente).State = EntityState.Modified;
            _context.Entry(cliente.Genero).State = EntityState.Modified;
            _context.Entry(cliente.EnderecoCobranca).State = EntityState.Modified;
            _context.Entry(cliente.EnderecoEntrega).State = EntityState.Modified;
            _context.Entry(cliente.CartaoCredito).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir (EntidadeDominio entidadeDominio)
        {
            Cliente cliente = (Cliente)entidadeDominio;

            var clienteBanco = (Cliente)await ConsultarId(cliente.Id);
            _context.Cliente.Remove(clienteBanco);
            await _context.SaveChangesAsync();
            
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Cliente.FindAsync(id);
            return entidadeDominio;
        }

        public async Task<EntidadeDominio> ConsultaClienteLogado(int id)
        {
            var entidadeDominio = await _context.Cliente.FindAsync(id);
            var entidadeDominioEnderecoCobranca = await _context.EnderecoCobranca.Include(c => c.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.ClienteId == entidadeDominio.Id);
            //var entidadeDominioEnderecoEntrega = await _context.EnderecoEntrega.Include(c => c.Cidade.Estado.Pais).FirstOrDefaultAsync(c => c.ClienteId == entidadeDominio.Id);
            //var entidadeDominioCartaoCredito = await _context.CartaoCredito.Include(c => c.Bandeira).FirstOrDefaultAsync(c => c.ClienteId == entidadeDominio.Id);
            entidadeDominio.EnderecoCobranca = entidadeDominioEnderecoCobranca;
            //entidadeDominio.EnderecoEntrega = entidadeDominioEnderecoEntrega;
            //entidadeDominio.CartaoCredito = entidadeDominioCartaoCredito;
            return entidadeDominio;
        }
        public async Task<IEnumerable<EntidadeDominio>> ConsultarPorId(int id)
        {
            List<Cliente> clientes = new List<Cliente>(); 
            clientes.Add(await _context.Cliente.Include(c => c.Carrinho.ItensCarrinho).FirstOrDefaultAsync(c => c.Id == id));
            return clientes;
        }

        public async Task<EntidadeDominio> ConsultarCliente(string nome, string cpf, string telefone)
        {
            if(nome != null)
            {
                var entidade = await _context.Cliente.FirstOrDefaultAsync(i => i.Nome == nome);
                return entidade;
            }
            else if(cpf != null)
            {
                var entidade = await _context.Cliente.FirstOrDefaultAsync(i => i.Cpf == cpf);
                return entidade;
            }

            var entidadeDominio = await _context.Cliente.FirstOrDefaultAsync(i => i.Telefone == telefone);
            return entidadeDominio;

        }

        public async  Task<EntidadeDominio> ConsultarClientePorUsuario(string email, string senha)
        {
            var entidadeDominio = await _context.Cliente.FirstOrDefaultAsync(i => i.Usuario.Email == email && i.Usuario.Senha == senha);
            return entidadeDominio;
        }

        public async Task<EntidadeDominio> ConsultarCarrinhoCliente(int carrinhoCompraId)
        {
            var entidadeDominio = await _context.ItemCarrinho.FirstOrDefaultAsync(i => i.CarrinhoCompraId == carrinhoCompraId);
            return entidadeDominio;
        }


    }
 
}
