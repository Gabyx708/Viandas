using Viandas.Application.DTO.DishDTO;

namespace Viandas.Application.Interface.IDish
{
    public interface IQueryDish
    {
        GetDishDTO GetDish(string dishId);
        GetDishesDTO GetDishes();
        GetDishesDTO GetDishByDescription(string description);
    }
}
