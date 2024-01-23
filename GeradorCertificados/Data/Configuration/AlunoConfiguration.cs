using GeradorCertificados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeradorCertificados.Data.Configuration;

public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Aluno");

        builder.HasKey(a => a.AlunoId);
        
        builder.Property(a => a.Matricula)
            .HasColumnName("Matricula")
            .IsRequired();
        
        builder.HasMany(x => x.Eventos)
            .WithMany(x => x.Alunos)
            .UsingEntity<Dictionary<string, object>>(
                "Aluno_Evento",
                y => y.HasOne<Evento>()
                    .WithMany()
                    .HasForeignKey("EventoId")
                    .OnDelete(DeleteBehavior.Cascade),
                y => y.HasOne<Aluno>()
                    .WithMany()
                    .HasForeignKey("AlunoId")
                    .OnDelete(DeleteBehavior.Cascade)
            );
            

    }
}