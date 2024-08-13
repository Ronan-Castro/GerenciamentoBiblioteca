using GerenciamentoBiblioteca.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
        }
    }
}
