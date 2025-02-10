namespace Viandas.Application.DTO.DishDTO
{
    public class GetDishDTO
    {
        public GetDishDTO(string id, string description, DateTime creationDate, string userId, string fullName)
        {
            Id = id;
            Description = description;
            CreationDate = creationDate;
            Creator = new CreatorUser(userId, fullName);
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public CreatorUser Creator { get; private set; }

    }

    public class CreatorUser
    {
        public CreatorUser(string userId, string fullName)
        {
            UserId = userId;
            FullName = fullName;
        }

        public string UserId { get; set; }
        public string FullName { get; set; }

    }
}
