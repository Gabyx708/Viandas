using Viandas.Application.DTO.UserDTO;

namespace Viandas.Application.Interface.IUser
{
    public interface ICreateUser
    {
        bool CreateUser(CreateUserDTO user);
    }
}
