using Microsoft.EntityFrameworkCore;

namespace MercadoIGL.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        // DbSets para as tabelas do banco de dados
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } // DbSet para a tabela 'Usuarios'

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para a tabela 'Clientes'
            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes", t => t.HasTrigger("trg_UpdateClienteNome"));

            // Configuração para a tabela 'Fornecedores'
            modelBuilder.Entity<Fornecedor>()
                .ToTable("Fornecedores");

            // Configuração para a tabela 'Funcionarios'
            modelBuilder.Entity<Funcionario>()
                .ToTable("Funcionarios", t => t.HasTrigger("trg_UpdateFuncionarioNome"));

            // Configuração para a tabela 'Produtos'
            modelBuilder.Entity<Produto>()
                .ToTable("Produtos", t => t.HasTrigger("trg_UpdateProdutoNome"));

            // Configuração detalhada para a tabela 'Usuarios'
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id); // Define a chave primária

                entity.Property(u => u.Nome)
                      .IsRequired()
                      .HasMaxLength(100); // Nome obrigatório com no máximo 100 caracteres

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(100); // Email obrigatório com no máximo 100 caracteres

                entity.HasIndex(u => u.Email)
                      .IsUnique(); // Email deve ser único

                entity.Property(u => u.SenhaHash)
                      .IsRequired()
                      .HasMaxLength(255); // Senha obrigatória com hash de no máximo 255 caracteres

                entity.Property(u => u.DataCriacao)
                      .HasDefaultValueSql("GETDATE()"); // Data de criação com valor padrão
            });

            // Configuração para a tabela 'Vendas'
            modelBuilder.Entity<Venda>()
                .ToTable("Vendas");
        }
    }
}
