using Microsoft.EntityFrameworkCore;
using Viandas.Infrastructure.Data.EntityConfig;
using Viandas.Infrastructure.Data.EntityModel;
using Viandas.Infrastructure.Data.EntityModels;
using Viandas.Infrastructure.Data.EntityModels.OrderModels;

namespace Viandas.Infrastructure.Data.Db
{
    public class AppDb : DbContext
    {
        public DbSet<DiscountModel> Discount { get; set; }
        public DbSet<DishModel> Dish { get; set; }
        public DbSet<MenuModel> Menu { get; set; }
        public DbSet<MenuOptionModel> MenuOption { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderTransitionModel> OrderTransitions { get; set; }
        public DbSet<UserModel> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Viandas2025v0;User Id=postgres;Password=ded572vb;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DiscountModelConfig());
            modelBuilder.ApplyConfiguration(new DishModelConfig());
            modelBuilder.ApplyConfiguration(new MenuModelConfig());
            modelBuilder.ApplyConfiguration(new MenuOptionConfig());
            modelBuilder.ApplyConfiguration(new OrderItemModelConfig());
            modelBuilder.ApplyConfiguration(new OrderModelConfig());
            modelBuilder.ApplyConfiguration(new OrderTransitionModelConfig());
            modelBuilder.ApplyConfiguration(new UserModelConfig());

        }
    }
}
