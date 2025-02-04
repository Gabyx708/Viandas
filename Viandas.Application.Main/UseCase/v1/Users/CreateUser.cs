using Viandas.Application.DTO.UserDTO;
using Viandas.Application.Interface;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Application.Main.UseCase.v1.Users
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        bool ICreateUser.CreateUser(CreateUserDTO user)
        {

            var newUser = MapToUser(user);

            try
            {
                _userRepository.InsertUser(newUser);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private User MapToUser(CreateUserDTO user)
        {
            return new User(user.UserId,
                            user.Name,
                            user.Name,
                            user.LastName,
                            user.UserId,
                            user.BirthDay);
        }
    }
}
