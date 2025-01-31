namespace Viandas.Infrastructure.Data.EntityModel
{
    public class MenuModel
    {
        public required string MenuID { get; set; }
        public required string UserResponsibleId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public DateTime OrderDeadLine { get; set; }
        public required UserModel Responsible { get; set; }
        public required virtual ICollection<MenuOptionModel> Options { get; set; }
        public required virtual ICollection<OrderModel> Orders { get; set; }
    }
}
