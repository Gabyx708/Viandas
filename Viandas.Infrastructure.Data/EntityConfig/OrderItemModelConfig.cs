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

        }
    }
}
