using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using GerenciamentoBiblioteca.Model;

namespace GerenciamentoBiblioteca.Data.Mapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(l => l.Id);

            builder
                .Property(l => l.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(l => l.Autor)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(l => l.ISBN)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(l => l.Estoque)
                .IsRequired()
                .HasColumnType("INT");

            builder
                .Property(l => l.AnoPublicacao)
                .IsRequired()
                .HasColumnType("INT");


            builder.HasMany(x => x.Emprestimos)
                .WithOne()
                .HasForeignKey(x => x.IdLivro)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
