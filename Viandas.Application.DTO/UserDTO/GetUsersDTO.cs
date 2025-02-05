namespace Viandas.Application.DTO.UserDTO
{
    public class GetUsersDTO
    {
        public List<GetUserDTO> Users { get; set; }

        public GetUsersDTO(List<GetUserDTO> users)
        {
            Users = users;
        }
    }
}
