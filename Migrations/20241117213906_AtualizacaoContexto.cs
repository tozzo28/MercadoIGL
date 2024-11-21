using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadoIGL.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoContexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_cnpjFornecedor",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_cpfCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Funcionarios_cpfFuncionario",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_idProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_cpfCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_cpfFuncionario",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_idProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_cnpjFornecedor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "cpfCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "cpfFuncionario",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "idProduto",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "cnpjFornecedor",
                table: "Produtos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data",
                table: "Vendas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteID",
                table: "Vendas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_FuncionarioID",
                table: "Vendas",
                column: "FuncionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutoID",
                table: "Vendas",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_cnpjID",
                table: "Produtos",
                column: "cnpjID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_cnpjID",
                table: "Produtos",
                column: "cnpjID",
                principalTable: "Fornecedores",
                principalColumn: "cnpjFornecedor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteID",
                table: "Vendas",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "cpfCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioID",
                table: "Vendas",
                column: "FuncionarioID",
                principalTable: "Funcionarios",
                principalColumn: "cpfFuncionario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_ProdutoID",
                table: "Vendas",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "idProduto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_cnpjID",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteID",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Funcionarios_FuncionarioID",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_ProdutoID",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClienteID",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_FuncionarioID",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ProdutoID",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_cnpjID",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "data",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cpfCliente",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cpfFuncionario",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idProduto",
                table: "Vendas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cnpjFornecedor",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_cpfCliente",
                table: "Vendas",
                column: "cpfCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_cpfFuncionario",
                table: "Vendas",
                column: "cpfFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_idProduto",
                table: "Vendas",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_cnpjFornecedor",
                table: "Produtos",
                column: "cnpjFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_cnpjFornecedor",
                table: "Produtos",
                column: "cnpjFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "cnpjFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_cpfCliente",
                table: "Vendas",
                column: "cpfCliente",
                principalTable: "Clientes",
                principalColumn: "cpfCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Funcionarios_cpfFuncionario",
                table: "Vendas",
                column: "cpfFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "cpfFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_idProduto",
                table: "Vendas",
                column: "idProduto",
                principalTable: "Produtos",
                principalColumn: "idProduto");
        }
    }
}
