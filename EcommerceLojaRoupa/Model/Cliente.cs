using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Cliente : EntidadeDominio
    {
        public bool Ativo { get; set; }
        public string Codigo { get; set; }
        public string Genero { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public Endereco EnderecoCobranca { get; set; }

    }
}
