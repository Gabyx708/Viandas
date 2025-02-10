using Viandas.Application.DTO.DishDTO;
using Viandas.Application.Interface.IDish;
using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Application.Main.UseCase.v1.Dishes
{
    public class QueryDish : IQueryDish
    {
        private readonly IDishRepository _dishRepository;
        private readonly IUserRepository _userRepository;

        public QueryDish(IDishRepository dishRepository, IUserRepository userRepository)
        {
            _dishRepository = dishRepository;
            _userRepository = userRepository;
        }

        public GetDishDTO GetDish(string dishId)
        {
            var dish = _dishRepository.GetById(dishId);

            if (dish == null)
            {
                throw new NullReferenceException();
            }

            return MapToDTO(dish);
        }

        public GetDishesDTO GetDishByDescription(string description)
        {
            var dishes = _dishRepository.GetDishByDescription(description);

            var list = dishes.Select(d => MapToDTO(d)).ToList();
            return new GetDishesDTO(list);
        }

        public GetDishesDTO GetDishes()
        {
            var dishes = _dishRepository.GetDishes()
                                  .Select(d => MapToDTO(d))
                                  .ToList();

            return new GetDishesDTO(dishes);
        }

        private GetDishDTO MapToDTO(Dish dish)
        {
            var user = _userRepository.GetById(dish.UserID);

            return new GetDishDTO(dish.Id,
                                  dish.Description,
                                  dish.CreationDate,
                                  user.GetId(),
                                  user.GetFullName());

        }
    }
}
