using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            _ = builder.HasKey(e => e.Id).HasName("PK__Eventos__7944C8108A787BD7");
            _ = builder.Property(e => e.Id).HasColumnName("EventId");

            _ = builder.Property(e => e.DateEvent)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            _ = builder.Property(e => e.Description).HasMaxLength(255);
            _ = builder.Property(e => e.TypeEvent).HasMaxLength(150);

            _ = builder.HasOne(d => d.User).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Eventos__UserId__440B1D61");
        }
    }
}
