namespace Viandas.Application.DTO.DishDTO
{
    public class GetDishesDTO
    {
        public List<GetDishDTO> Dishes { get; set; }

        public GetDishesDTO(List<GetDishDTO> dishes)
        {
            Dishes = dishes;
        }
    }
}
