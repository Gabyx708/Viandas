using Viandas.Application.Interface.IUser;
using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Application.Main.UseCase.v1.Users
{
    public class DeleteUser : IDeleteUser
    {
        private readonly IUserRepository _userRepository;

        public DeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool DisableUser(string userId)
        {
            User foundUser;

            try
            {
                foundUser = _userRepository.GetById(userId);
            }
            catch (NullReferenceException)
            {
                return false;
            }

            foundUser.Disable();
            _userRepository.UpdateUser(foundUser);

            return true;
        }
    }
}
