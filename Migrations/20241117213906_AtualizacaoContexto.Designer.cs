﻿// <auto-generated />
using System;
using MercadoIGL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MercadoIGL.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241117213906_AtualizacaoContexto")]
    partial class AtualizacaoContexto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MercadoIGL.Models.Cliente", b =>
                {
                    b.Property<int>("cpfCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cpfCliente"));

                    b.Property<string>("endereco")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("cpfCliente");

                    b.ToTable("Clientes", null, t =>
                        {
                            t.HasTrigger("trg_UpdateClienteNome");
                        });
                });

            modelBuilder.Entity("MercadoIGL.Models.Fornecedor", b =>
                {
                    b.Property<int>("cnpjFornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cnpjFornecedor"));

                    b.Property<string>("empresa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("telefone")
                        .HasColumnType("int");

                    b.HasKey("cnpjFornecedor");

                    b.ToTable("Fornecedores", (string)null);
                });

            modelBuilder.Entity("MercadoIGL.Models.Funcionario", b =>
                {
                    b.Property<int>("cpfFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cpfFuncionario"));

                    b.Property<string>("cargo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("cpfFuncionario");

                    b.ToTable("Funcionarios", null, t =>
                        {
                            t.HasTrigger("trg_UpdateFuncionarioNome");
                        });
                });

            modelBuilder.Entity("MercadoIGL.Models.Produto", b =>
                {
                    b.Property<int>("idProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProduto"));

                    b.Property<int>("cnpjID")
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("estoque")
                        .HasColumnType("int");

                    b.Property<float>("valorUnitario")
                        .HasColumnType("real");

                    b.HasKey("idProduto");

                    b.HasIndex("cnpjID");

                    b.ToTable("Produtos", null, t =>
                        {
                            t.HasTrigger("trg_UpdateProdutoNome");
                        });
                });

            modelBuilder.Entity("MercadoIGL.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MercadoIGL.Models.Venda", b =>
                {
                    b.Property<int>("idVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVenda"));

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioID")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("QntdVendida")
                        .HasColumnType("int");

                    b.Property<DateTime?>("data")
                        .HasColumnType("datetime2");

                    b.Property<float>("valorTotal")
                        .HasColumnType("real");

                    b.HasKey("idVenda");

                    b.HasIndex("ClienteID");

                    b.HasIndex("FuncionarioID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Vendas", (string)null);
                });

            modelBuilder.Entity("MercadoIGL.Models.Produto", b =>
                {
                    b.HasOne("MercadoIGL.Models.Fornecedor", "fornecedor")
                        .WithMany()
                        .HasForeignKey("cnpjID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fornecedor");
                });

            modelBuilder.Entity("MercadoIGL.Models.Venda", b =>
                {
                    b.HasOne("MercadoIGL.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadoIGL.Models.Funcionario", "funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MercadoIGL.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("funcionario");

                    b.Navigation("produto");
                });
#pragma warning restore 612, 618
        }
    }
}
