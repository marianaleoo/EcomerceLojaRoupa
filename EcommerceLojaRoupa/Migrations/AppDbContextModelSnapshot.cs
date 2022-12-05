﻿// <auto-generated />
using System;
using EcommerceLojaRoupa.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcommerceLojaRoupa.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Bandeira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bandeira");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.CarrinhoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CarrinhoCompra");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.CartaoCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BandeiraId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoSeguranca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeCartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidadeCartao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BandeiraId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("CartaoCredito");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estadoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("estadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmarSenha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DDD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoTelefoneId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("TipoTelefoneId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartaoCreditoId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("CupomTrocaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoEntregaId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CartaoCreditoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnderecoEntregaId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.CupomPromocional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CupomPromocional");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.CupomTroca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valorTroca")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CupomTroca");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.DetalheAtivacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DetalheAtivacao");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.EnderecoCobranca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoLogradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoResidencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cidadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("cidadeId");

                    b.ToTable("EnderecoCobranca");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.EnderecoEntrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoLogradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoResidencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cidadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("cidadeId");

                    b.ToTable("EnderecoEntrega");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("paisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("paisId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("ValorCompra")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.ItemCarrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarrinhoCompraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("RoupaId")
                        .HasColumnType("int");

                    b.Property<string>("Tamanho")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoCompraId");

                    b.HasIndex("RoupaId");

                    b.ToTable("ItemCarrinho");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.ItemCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AceitarTroca")
                        .HasColumnType("bit");

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<int?>("CupomTrocaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<bool>("RecusarTroca")
                        .HasColumnType("bit");

                    b.Property<int>("RoupaId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("CupomTrocaId");

                    b.HasIndex("RoupaId");

                    b.ToTable("ItemCompra");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Roupa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<string>("Tecido")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roupa");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoTelefone");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.CartaoCredito", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.Bandeira", "Bandeira")
                        .WithMany()
                        .HasForeignKey("BandeiraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.Cliente", null)
                        .WithOne("CartaoCredito")
                        .HasForeignKey("EcommerceLojaRoupa.Model.CartaoCredito", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bandeira");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Cidade", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("estadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Cliente", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.CarrinhoCompra", "Carrinho")
                        .WithMany()
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.TipoTelefone", "TipoTelefone")
                        .WithMany()
                        .HasForeignKey("TipoTelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Genero");

                    b.Navigation("TipoTelefone");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Compra", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.CartaoCredito", "CartaoCredito")
                        .WithMany()
                        .HasForeignKey("CartaoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.EnderecoEntrega", "EnderecoEntrega")
                        .WithMany()
                        .HasForeignKey("EnderecoEntregaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartaoCredito");

                    b.Navigation("Cliente");

                    b.Navigation("EnderecoEntrega");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.EnderecoCobranca", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.Cliente", null)
                        .WithOne("EnderecoCobranca")
                        .HasForeignKey("EcommerceLojaRoupa.Model.EnderecoCobranca", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("cidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.EnderecoEntrega", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.Cliente", null)
                        .WithOne("EnderecoEntrega")
                        .HasForeignKey("EcommerceLojaRoupa.Model.EnderecoEntrega", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("cidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Estado", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("paisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.ItemCarrinho", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.CarrinhoCompra", null)
                        .WithMany("ItensCarrinho")
                        .HasForeignKey("CarrinhoCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.Roupa", "Roupa")
                        .WithMany()
                        .HasForeignKey("RoupaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roupa");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.ItemCompra", b =>
                {
                    b.HasOne("EcommerceLojaRoupa.Model.Compra", null)
                        .WithMany("ItensCompra")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcommerceLojaRoupa.Model.CupomTroca", "CupomTroca")
                        .WithMany()
                        .HasForeignKey("CupomTrocaId");

                    b.HasOne("EcommerceLojaRoupa.Model.Roupa", "Roupa")
                        .WithMany()
                        .HasForeignKey("RoupaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CupomTroca");

                    b.Navigation("Roupa");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.CarrinhoCompra", b =>
                {
                    b.Navigation("ItensCarrinho");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Cliente", b =>
                {
                    b.Navigation("CartaoCredito");

                    b.Navigation("EnderecoCobranca");

                    b.Navigation("EnderecoEntrega");
                });

            modelBuilder.Entity("EcommerceLojaRoupa.Model.Compra", b =>
                {
                    b.Navigation("ItensCompra");
                });
#pragma warning restore 612, 618
        }
    }
}
