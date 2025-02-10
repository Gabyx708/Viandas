using Viandas.Application.DTO.MenuDTO;
using Viandas.Application.Interface.IFactory;
using Viandas.Application.Interface.IMenu;
using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Application.Main.UseCase.v1.Menues
{
    public class CreateMenu : ICreateMenu
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMenuFactory _factory;
        public CreateMenu(IMenuRepository menuRepository, IMenuFactory factory)
        {
            _menuRepository = menuRepository;
            _factory = factory;
        }

        GetMenuSimpleDTO ICreateMenu.CreateMenu(CreateMenuDTO menu,string userId)
        {
            Menu newMenu;
            
            try
            {
                newMenu = _factory.Create(menu, userId);
            }catch(Exception ex)
            {
                throw new NullReferenceException();
            }

            _menuRepository.InsertMenu(newMenu);

            return CreateDTO(newMenu);
        }

        private GetMenuSimpleDTO CreateDTO(Menu menu)
        {
            User user = menu.Responsible;
            List<MenuItem> items = CreateItems(menu.Options.ToList());

            MenuResponsibleDTO responsible = new MenuResponsibleDTO(user.GetId(), user.GetFullName());

            return new GetMenuSimpleDTO(menu.Id,
                                        menu.CreationDate,
                                        menu.ConsumptionDate,
                                        menu.OrderDeadLine,responsible,
                                        items,
                                        "available");
        }

        private List<MenuItem> CreateItems(List<MenuOption> menuOptions)
        {
           return menuOptions.Select(o => MapOption(o)).ToList();
        }

        private MenuItem MapOption(MenuOption option)
        {
            return new MenuItem(option.DishID, 
                                option.GetDescription(),
                                option.GetPrice(),
                                option.Stock,
                                option.GetAvailable());
        }
    }
}
