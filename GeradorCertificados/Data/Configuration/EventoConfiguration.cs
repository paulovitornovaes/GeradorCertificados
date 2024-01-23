using GeradorCertificados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.ToTable("Evento");

        builder.HasKey(e => e.EventoId);

        builder.HasMany(x => x.Alunos)
            .WithMany(x => x.Eventos);

        // Adicione outras configurações de propriedade, se necessário.
    }
}