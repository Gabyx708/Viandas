using Viandas.Domain.Core.AggregatesModel.UserAggregate;

namespace Viandas.Infrastructure.Interface.IRepositories
{ 
    public interface IUserRepository
    {
        User GetAuthenticatedUser(string userID, string password);
        User GetById(string userID);
        User InsertUser(User user);
        List<User> GetActivatedUsers();
        User UpdateUser(User user);
    }
}
