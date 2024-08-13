using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using GerenciamentoBiblioteca.Model;
using System.Reflection.Emit;

namespace GerenciamentoBiblioteca.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ToTable("Usuarios");

            builder.HasKey(x=>x.Id);

            builder
                .Property(x=>x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            //Relacionamentos
            builder.HasMany(x => x.Emprestimos)
                .WithOne()
                .HasForeignKey(x => x.IdUsuario)
                .IsRequired();

        }
    
    }
}


/*Possibilidades SQL SERVER

modelBuilder.Entity<MyEntity>(entity =>
    {
        entity.Property(e => e.Id)
            .HasColumnType("INT")
            .IsRequired()
            .ValueGeneratedOnAdd();

        entity.Property(e => e.Name)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();

        entity.Property(e => e.Description)
            .HasColumnType("TEXT");

        entity.Property(e => e.Age)
            .HasColumnType("TINYINT");

        entity.Property(e => e.Price)
            .HasColumnType("DECIMAL(18,2)");
        entity.Property(e => e.CreatedAt)
            .HasColumnType("DATETIME") // Define o tipo DATETIME
            .IsRequired();
    });

*/