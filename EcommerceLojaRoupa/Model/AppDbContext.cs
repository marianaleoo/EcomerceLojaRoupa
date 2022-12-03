using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks ;

namespace EcommerceLojaRoupa.Model
{
    public class AppDbContext : DbContext
    {
        //definição do meu contexto
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        //mapeamento da entidade
        public DbSet<Roupa> Roupa { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinho { get; set; }
        public DbSet<DetalheAtivacao> DetalheAtivacao { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<CartaoCredito> CartaoCredito { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<CupomPromocional> CupomPromocional { get; set; }
        public DbSet<CupomTroca> CupomTroca { get; set; }
        public DbSet<EnderecoCobranca> EnderecoCobranca { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntrega { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<ItemCompra> ItemCompra { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<CarrinhoCompra> CarrinhoCompra { get; set; }
        public DbSet<Bandeira> Bandeira { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }

        public DbSet<Compra> Compra { get; set; }
             


    }
}
