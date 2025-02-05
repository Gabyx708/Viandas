using Viandas.Application.DTO.UserDTO;
using Viandas.Application.Interface.IUser;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Application.Main.UseCase.v1.Users
{
    public class QueryUser : IQueryUser
    {
        private readonly IUserRepository _userRepository;

        public QueryUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public GetUserDTO GetUser(string userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            return MapToGetUser(user);
        }

        public GetUsersDTO GetUsers()
        {
            var users = _userRepository.GetActivatedUsers();

           List<GetUserDTO> usersDTO = users.Select(u => MapToGetUser(u))
                                            .ToList();

            return new GetUsersDTO(usersDTO);
        }

        private GetUserDTO MapToGetUser(User user)
        {
            return new GetUserDTO
            (
                user.GetId(),
                user.Name,
                user.LastName,
                user.BirthDate,
                user.CreationDate,
                user.NickName
            );
        }

    }
}
