using Viandas.Application.DTO.MenuDTO;
using Viandas.Application.Interface.IFactory;
using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Application.Main.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private readonly IUserRepository _userRepository;
        private readonly IDishRepository _dishRepository;

        public MenuFactory(IUserRepository userRepository, IDishRepository dishRepository)
        {
            _userRepository = userRepository;
            _dishRepository = dishRepository;
        }

        public Menu Create(CreateMenuDTO createDTO, string creatorId)
        {
            User responsible = _userRepository.GetById(creatorId);

            var menu = CreateBasic(createDTO, responsible);

            AddOptions(menu, createDTO.Items);

            return menu;
        }

        private Menu CreateBasic(CreateMenuDTO createDTO, User responsible)
        {
            return new Menu(responsible,
                            createDTO.ConsumptionDate,
                            createDTO.OrderDeadLine,
                            DateTime.Now);
        }
        private void AddOptions(Menu menu, List<MenuItemDTO> items)
        {
            var options = items;

            foreach (var item in options)
            {
                Dish dish = _dishRepository.GetById(item.DishId);
                int stock = item.Stock;

                menu.AddOption(dish, stock);
            }
        }
    }
}
