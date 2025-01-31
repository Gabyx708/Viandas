using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModels.OrderModels;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    public class DiscountModelConfig : IEntityTypeConfiguration<DiscountModel>
    {
        public void Configure(EntityTypeBuilder<DiscountModel> builder)
        {
            builder.ToTable("Discount");
            builder.HasKey(d => d.DiscountID);

        }
    }
}
