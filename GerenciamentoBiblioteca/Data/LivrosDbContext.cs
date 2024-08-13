using GerenciamentoBiblioteca.Data.Mapping;
using GerenciamentoBiblioteca.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Data
{
    public class LivrosDbContext(DbContextOptions<LivrosDbContext> options)
        : DbContext(options)
    {
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Emprestimo>? Emprestimos { get; set; }
        public DbSet<Livro>? Livros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
        }
    }
}
