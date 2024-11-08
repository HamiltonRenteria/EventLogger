using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            _ = builder.HasKey(e => e.Id).HasName("PK__Users__1788CC4C23DE0916");
            _ = builder.Property(e => e.Id).HasColumnName("UserId");

            _ = builder.HasIndex(e => e.Email, "UQ__Users__A9D105349379B89E").IsUnique();

            _ = builder.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            _ = builder.Property(e => e.Email).HasMaxLength(100);
            _ = builder.Property(e => e.UserName).HasMaxLength(100);
        }
    }
}
