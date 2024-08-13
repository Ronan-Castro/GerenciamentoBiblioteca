using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using GerenciamentoBiblioteca.Model;

namespace GerenciamentoBiblioteca.Data.Mapping
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
                .Property(u => u.ValorEmprestimo)
                .IsRequired()
                .HasColumnType("DECIMAL(15,2)");

            builder
                .Property(u => u.Status)
                .HasColumnName("StatusEmprestimo")
                .IsRequired()
                .HasColumnType("INT");

            builder
                .Property(u => u.DataEmprestimo)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder
                .Property(u => u.DataDevolucao)
                .IsRequired()
                .HasColumnType("DATETIME");


        }
    }
}
