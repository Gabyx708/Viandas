using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    internal class MenuOptionConfig : IEntityTypeConfiguration<MenuOptionModel>
    {
        public void Configure(EntityTypeBuilder<MenuOptionModel> builder)
        {
            builder.ToTable("MenuOptions");

            builder.HasKey(o => new { o.MenuID, o.DishID });

            builder.HasOne(o => o.Menu)
              .WithMany(m => m.Options)
              .HasForeignKey(o => o.MenuID)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Dish)
              .WithMany(m => m.Options)
              .HasForeignKey(o => o.DishID)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
