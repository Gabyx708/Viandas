using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class DishModel : IEntityModel<Dish,DishModel>
    {
        public string DishID { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string UserID { get; set; } = null!;
        public DateTime CreationDate { get; set; }

        public  UserModel? User { get; set; }
        public  virtual ICollection<MenuOptionModel>? Options { get; set; }

        public Dish MapToEntity()
        {
            return new Dish(DishID,Description,Price, UserID,CreationDate.ToLocalTime());
        }

        public DishModel MapToModel(Dish dish)
        {
            return new DishModel
            {
                DishID = dish.Id,
                Description = dish.Description,
                Price = dish.GetPrice(),
                UserID = dish.UserID,
                CreationDate = dish.CreationDate.ToUniversalTime(),
                User = null,
                Options = new List<MenuOptionModel>()
            };
        }

    }
}
