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
                return 
            }

            return MapToGetUser(user);
        }

        public List<GetUserDTO> GetUsers()
        {
            throw new NotImplementedException();
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
