using Viandas.Application.DTO.MenuDTO;

namespace Viandas.Application.Interface.IMenu
{
    public interface ICreateMenu
    {
        GetMenuSimpleDTO CreateMenu(CreateMenuDTO menu,string userId);
    }
}
