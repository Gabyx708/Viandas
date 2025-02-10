namespace Viandas.Application.DTO.MenuDTO
{
    public record CreateMenuDTO
    {
        public CreateMenuDTO(DateTime consumptionDate, DateTime orderDeadLine, List<MenuItemDTO> items)
        {
            ConsumptionDate = consumptionDate;
            OrderDeadLine = orderDeadLine;
            Items = items;
        }

        public DateTime ConsumptionDate { get; set; }
        public DateTime OrderDeadLine { get; set; }
        public List<MenuItemDTO> Items { get; set; }
    }

    public record MenuItemDTO
    {
        public MenuItemDTO(string dishId, int stock)
        {
            DishId = dishId;
            Stock = stock;
        }

        public string DishId { get; set; }
        public int Stock { get; set; }
    }
}
