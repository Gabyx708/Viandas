using Viandas.Application.Interface.IDish;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Application.Main.UseCase.v1.Dishes
{
    public class UpdateDishesPrices : IUpdateDishesPrice
    {
        private readonly IDishRepository _dishRepository;

        public UpdateDishesPrices(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public bool UpdatePrices(decimal price)
        {
            return _dishRepository.UpdateAllPrices(price);
        }
    }
}
