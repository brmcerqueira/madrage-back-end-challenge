using MadrageBackEndChallenge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MadrageBackEndChallenge.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(30);
            builder.Property(x => x.Password).HasColumnName("password").IsRequired().HasMaxLength(60);
        }
    }
}