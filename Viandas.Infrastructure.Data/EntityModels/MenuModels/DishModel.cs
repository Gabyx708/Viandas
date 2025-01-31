using Viandas.Domain.Core.AggregatesModel.MenuAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class DishModel : IEntityModel<Dish,DishModel>
    {
        public required string DishID { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string UserID { get; set; }
        public DateTime CreationDate { get; set; }

        public required UserModel User { get; set; }
        public required virtual ICollection<MenuOptionModel> Options { get; set; }

        public Dish MapToEntity()
        {
            return new Dish(DishID,Description,Price, UserID);
        }

        public DishModel MapToModel(Dish dish)
        {
            return new DishModel
            {
                DishID = dish.Id,
                Description = dish.Description,
                Price = dish.GetPrice(),
                UserID = dish.UserID,
                CreationDate = dish.CreationDate,
                User = null,
                Options = null
            };
        }

    }
}
