using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Infrastructure.Data.Db;
using Viandas.Infrastructure.Data.EntityModel;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Infrastructure.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly AppDb _conext;

        public DishRepository(AppDb conext)
        {
            _conext = conext;
        }

        public Dish GetById(string dishId)
        {
            var found = _conext.Dish.Find(dishId);

            if (found != null)
            {
                return found.MapToEntity();
            }

            throw new NullReferenceException();
        }

        public List<Dish> GetDishByDescription(string description)
        {
            var dishes = _conext.Dish.Where(d => d.Description.Contains(description))
                                      .ToList();

            return dishes.Select(d => d.MapToEntity()).ToList();
        }

        public List<Dish> GetDishes()
        {
            return _conext.Dish.Select(d => d.MapToEntity()).ToList();
        }

        public Dish InsertDish(Dish dish)
        {
            var newDish = new DishModel().MapToModel(dish);
            _conext.Dish.Add(newDish);
            _conext.SaveChanges();

            return dish;
        }

        public bool UpdateAllPrices(decimal price)
        {
            try
            {
                var dihes = _conext.Dish.ToList(); //ineficiente , revisar a futuro

                foreach (var item in dihes)
                {
                    item.Price = price;
                }

                _conext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
