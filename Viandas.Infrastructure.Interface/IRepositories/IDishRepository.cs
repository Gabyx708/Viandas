using Viandas.Domain.Core.AggregatesModel.MenuAggregate;

namespace Viandas.Infrastructure.Interface.IRepositories
{
    public interface IDishRepository
    {
        Dish InsertDish(Dish dish);
        Dish GetById(string dishId);
        List<Dish> GetDishes();
        List<Dish> GetDishByDescription(string description);
        bool UpdateAllPrices(decimal price);
    }
}
