using Viandas.Application.DTO.UserDTO;

namespace Viandas.Application.Interface.IUser
{
    public interface IQueryUser
    {
        GetUserDTO GetUser(string userId);
        List<GetUserDTO> GetUsers();
    }
}
