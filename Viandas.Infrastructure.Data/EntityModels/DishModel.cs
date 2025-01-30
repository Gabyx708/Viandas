namespace Viandas.Infrastructure.Data.EntityModel
{
    public class DishModel
    {
        public required string DishID { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string UserID { get; set; }
        public DateTime CreationDate { get; set; }

        public required UserModel User { get; set; }
    }
}
