using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    public class OrderModelConfig : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(o => o.OrderID);

            builder.HasOne(o => o.UserModel)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserID);

            builder.HasOne(o => o.DiscountModel)
                   .WithMany(d => d.OrderModels)
                   .HasForeignKey(o => o.DiscountID);
        }
    }
}
