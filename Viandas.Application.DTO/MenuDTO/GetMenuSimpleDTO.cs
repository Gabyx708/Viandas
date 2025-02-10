namespace Viandas.Application.DTO.MenuDTO
{
    public record GetMenuSimpleDTO
    {
        public GetMenuSimpleDTO(string menuId,
                                DateTime createdDate,
                                DateTime consumptionDate,
                                DateTime orderDeadLine,
                                MenuResponsibleDTO responsible,
                                List<MenuItem> items,
                                string status)
        {
            MenuId = menuId;
            CreatedDate = createdDate;
            ConsumptionDate = consumptionDate;
            OrderDeadLine = orderDeadLine;
            Responsible = responsible;
            Items = items;
            Status = status;
        }

        public string MenuId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public DateTime OrderDeadLine { get; set; }
        public MenuResponsibleDTO Responsible { get; set; }
        public List<MenuItem> Items { get; set; }
        public string Status { get; set; }

    }

    public record MenuResponsibleDTO(string UserId, string FullName);

    public record MenuItem(string DishId, string Description, decimal Price, int Stock, int Available);
}
