using Microsoft.EntityFrameworkCore;
using Viandas.Infrastructure.Data.EntityConfig;
using Viandas.Infrastructure.Data.EntityModel;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.Db
{
    public class AppDb : DbContext
    {
     
       public DbSet<UserModel> User { get; set; }   
       public DbSet<DiscountModel> Discount { get; set; }   
       public DbSet<DishModel> Dish { get; set; }
       public DbSet<MenuModel> Menu { get; set; }
       public DbSet<MenuOptionModel> MenuOption { get; set; }
       public DbSet<OrderModel> Orders { get; set; }
       public DbSet<OrderItemModel> OrderItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserModelConfig());
            modelBuilder.ApplyConfiguration(new DiscountModelConfig());
            modelBuilder.ApplyConfiguration(new OrderModelConfig());
            modelBuilder.ApplyConfiguration(new OrderItemModelConfig());
            modelBuilder.ApplyConfiguration(new MenuModelConfig());
            modelBuilder.ApplyConfiguration(new DishModelConfig());
            modelBuilder.ApplyConfiguration(new MenuOptionConfig());
        }
    }
}
