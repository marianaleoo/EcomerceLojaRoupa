using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Dao
{
    public class UsuarioDao : IDao

    {
        private readonly AppDbContext _context;

        public UsuarioDao(AppDbContext context)
        {
            _context = context;
        }

        public UsuarioDao()
        {
        }
        public Task Alterar(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<EntidadeDominio>> Consultar(EntidadeDominio entidadeDominio)
        {
            Usuario usuario = (Usuario)entidadeDominio;
            
            if (usuario.Id != 0 )
            {
                List<EntidadeDominio> usuarios = new List<EntidadeDominio>();
                usuarios.Add(await ConsultarId(usuario.Id));
                foreach(var item in usuarios)
                {
                    if (item.Id == usuario.Id)
                    {
                        return await _context.Usuario.ToListAsync();
                    }
                }
                return usuarios;
            }
            return await _context.Usuario.ToListAsync();
        }
    

        public Task<EntidadeDominio> ConsultarCarrinhoCliente(int clienteId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EntidadeDominio> ConsultarId(int id)
        {
            var entidadeDominio = await _context.Usuario.FindAsync(id);
            return entidadeDominio;
        }

        public Task Excluir(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public Task Salvar(EntidadeDominio entidadeDominio)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EntidadeDominio> ConsultaUsuario(string email, string senha)
        {
            var entidadeDominioEmail = await _context.Usuario.FindAsync(email);
            var entidadeDominioSenha = await _context.Usuario.FindAsync(senha);
            if (entidadeDominioEmail.Email == email)
            {            
                if (entidadeDominioSenha.Senha == senha) ; 
            }

            return entidadeDominioSenha;
        }

        public Task<IEnumerable<EntidadeDominio>> ConsultarPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
