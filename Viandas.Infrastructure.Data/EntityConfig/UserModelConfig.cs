using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityConfig
{
    public class UserModelConfig : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.UserID);


        }
    }
}
