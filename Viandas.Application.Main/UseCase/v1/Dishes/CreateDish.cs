using Viandas.Application.DTO.DishDTO;
using Viandas.Application.Interface.IDish;
using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Infrastructure.Interface.IRepositories;
using Viandas.Transversal.Mapper;

namespace Viandas.Application.Main.UseCase.v1.Dishes
{
    public class CreateDish : ICreateDish
    {
        private readonly IDishRepository _dishRepository;
        private readonly IUserRepository _userRepository;

        public CreateDish(IDishRepository dishRepository, IUserRepository userRepository)
        {
            _dishRepository = dishRepository;
            _userRepository = userRepository;
        }

        GetDishDTO ICreateDish.CreateDish(CreateDishDTO dish)
        {
            var newDish = MapToDish(dish);

            Dish dishCreated;

           dishCreated = _dishRepository.InsertDish(newDish);

            return MapToDTO(dishCreated);
        }

        private Dish MapToDish(CreateDishDTO dto)
        {
            return new Dish(price: dto.Price,
                            userID: dto.UserId,
                            description: dto.Description
                            );
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
