using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModels.OrderModels;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    internal class OrderTransitionModelConfig : IEntityTypeConfiguration<OrderTransitionModel>
    {
        public void Configure(EntityTypeBuilder<OrderTransitionModel> builder)
        {
            builder.HasKey(ot => new { ot.OrderID, ot.UserID, ot.FromStatus, ot.ToStatus });

            builder.HasOne(ot => ot.OrderModel)
                    .WithMany(o => o.Transitions)
                    .HasForeignKey(ot => ot.OrderID);
        }
    }
}
