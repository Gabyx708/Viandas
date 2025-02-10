using Viandas.Application.DTO.DishDTO;

namespace Viandas.Application.Interface.IDish
{
    public interface ICreateDish
    {
        GetDishDTO CreateDish(CreateDishDTO dish);
    }
}
