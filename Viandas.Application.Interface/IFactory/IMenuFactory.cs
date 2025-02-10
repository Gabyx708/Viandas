using Viandas.Application.DTO.MenuDTO;
using Viandas.Domain.Core.AggregatesModel.MenuAggregate;

namespace Viandas.Application.Interface.IFactory
{
    public interface IMenuFactory
    {
        Menu Create(CreateMenuDTO createDTO,string userId);
    }
}
