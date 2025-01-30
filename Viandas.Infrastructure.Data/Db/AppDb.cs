using Microsoft.EntityFrameworkCore;
using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Domain.Core.AggregatesModel.OrderAggregate;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;

namespace Viandas.Infrastructure.Data.Db
{
    public class AppDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuOption> MenuOptions { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Discount> Discount { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderTransition> OrderTransition { get; set; }

    }
}
