using Viandas.Application.DTO.UserDTO;

namespace Viandas.Application.Interface
{
    public interface ICreateUser
    {
        bool CreateUser(CreateUserDTO user);
    }
}
