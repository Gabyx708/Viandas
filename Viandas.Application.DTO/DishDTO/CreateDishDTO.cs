namespace Viandas.Application.DTO.DishDTO
{
    public record CreateDishDTO
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string UserId { get; private set; }
        public CreateDishDTO(string description, decimal price, string userId)
        {
            Description = description;
            Price = price;
            UserId = userId;
        }
    }
}
