using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    internal class DishModelConfig : IEntityTypeConfiguration<DishModel>
    {
        public void Configure(EntityTypeBuilder<DishModel> builder)
        {
            builder.ToTable("Dishes");

            builder.HasKey(d => d.DishID);

            builder.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserID);



        }
    }

}
