namespace Viandas.Application.DTO.UserDTO
{
    public record GetUserDTO
    {
        public GetUserDTO(string userId, string name, string lastName, DateTime birthDay, DateTime createdDate, string nickName)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            BirthDay = birthDay;
            CreatedDate = createdDate;
            NickName = nickName;
        }

        public string UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime CreatedDate { get; set; }
        public string NickName { get; set; }

    }
}
