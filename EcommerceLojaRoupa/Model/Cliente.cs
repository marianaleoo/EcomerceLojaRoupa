using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLojaRoupa.Model
{
    public class Cliente : EntidadeDominio
    {
        public bool Ativo { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public int TipoTelefoneId { get; set; }
        [ForeignKey("TipoTelefoneId")]
        public TipoTelefone TipoTelefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public EnderecoCobranca EnderecoCobranca { get; set; }     
        public EnderecoEntrega EnderecoEntrega { get; set; }
        public CartaoCredito CartaoCredito { get; set; }
        public int GeneroId { get; set; }

        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario  { get; set; }

    }
}
