using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    internal class MenuModelConfig : IEntityTypeConfiguration<MenuModel>
    {
        public void Configure(EntityTypeBuilder<MenuModel> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.MenuID);

            builder.HasMany(m => m.Options)
              .WithOne(o => o.Menu)
              .HasForeignKey(o => o.MenuID)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Responsible)
              .WithMany() 
              .HasForeignKey(m => m.UserResponsibleId);
        }
    }
}
