using MadrageBackEndChallenge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MadrageBackEndChallenge.Persistence.Configurations
{
    public class MenuUserConfiguration : IEntityTypeConfiguration<MenuUser>
    {
        public void Configure(EntityTypeBuilder<MenuUser> builder)
        {
            builder.ToTable("menus_users");
            builder.HasKey(x => new { x.UserId, x.MenuId });
            builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(x => x.MenuId).HasColumnName("menu_id").IsRequired();
        }
    }
}