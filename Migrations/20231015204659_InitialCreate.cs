using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadoIGL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    cpfCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.cpfCliente);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    cnpjFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empresa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    telefone = table.Column<int>(type: "int", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.cnpjFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    cpfFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.cpfFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cnpjID = table.Column<int>(type: "int", nullable: false),
                    cnpjFornecedor = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    valorUnitario = table.Column<float>(type: "real", nullable: false),
                    estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.idProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_cnpjFornecedor",
                        column: x => x.cnpjFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "cnpjFornecedor");
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    idVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    idProduto = table.Column<int>(type: "int", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    cpfCliente = table.Column<int>(type: "int", nullable: true),
                    FuncionarioID = table.Column<int>(type: "int", nullable: false),
                    cpfFuncionario = table.Column<int>(type: "int", nullable: true),
                    QntdVendida = table.Column<int>(type: "int", nullable: false),
                    valorTotal = table.Column<float>(type: "real", nullable: false),
                    data = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.idVenda);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_cpfCliente",
                        column: x => x.cpfCliente,
                        principalTable: "Clientes",
                        principalColumn: "cpfCliente");
                    table.ForeignKey(
                        name: "FK_Vendas_Funcionarios_cpfFuncionario",
                        column: x => x.cpfFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "cpfFuncionario");
                    table.ForeignKey(
                        name: "FK_Vendas_Produtos_idProduto",
                        column: x => x.idProduto,
                        principalTable: "Produtos",
                        principalColumn: "idProduto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_cnpjFornecedor",
                table: "Produtos",
                column: "cnpjFornecedor");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
