using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    public class OrderItemModelConfig : IEntityTypeConfiguration<OrderItemModel>
    {
        public void Configure(EntityTypeBuilder<OrderItemModel> builder)
        {
            builder.ToTable("itemsDeOrdenes");

            builder.HasKey(o => new { o.OrderID, o.MenuID, o.DishID });

            builder.HasOne(ot => ot.OrderModel)
                    .WithMany(o => o.Items)
                    .HasForeignKey(ot => ot.OrderID);

            builder.HasOne(ot => ot.MenuOptionModel)
                   .WithMany(mop => mop.OrderItemModels)
                   .HasForeignKey(ot => new { ot.MenuID, ot.DishID });

        }
    }
}
