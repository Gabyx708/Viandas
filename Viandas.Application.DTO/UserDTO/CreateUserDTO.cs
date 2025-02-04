namespace Viandas.Application.DTO.UserDTO
{
    public record CreateUserDTO
    {
        public CreateUserDTO(string userId, string name, string lastName, DateTime birthDay, int rol)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            BirthDay = birthDay;
            Rol = rol;
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Rol { get; set; }
    }
}
