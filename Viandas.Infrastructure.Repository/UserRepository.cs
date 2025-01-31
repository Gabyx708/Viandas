using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Data.Db;
using Viandas.Infrastructure.Data.EntityModel;
using Viandas.Infrastructure.Interface.IRepositories;

namespace Viandas.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDb _context;

        public UserRepository(AppDb context)
        {
            _context = context;
        }

        public List<User> GetActivatedUsers()
        {
            var userModels = _context.User.Where(u => u.IsActivated == true).ToList();

            return userModels.Select(um => um.MapToEntity()).ToList();
        }

        public User GetAuthenticatedUser(string userID, string password)
        {
            var user = _context.User.Where(u => u.EncryptedPassword == password
                                           && u.UserID == userID)
                                           .FirstOrDefault();

            return user != null ? user.MapToEntity() : throw new DriveNotFoundException();
        }

        public User GetById(string userID)
        {
            var found = _context.User.Find(userID);

            if (found != null)
            {
                return found.MapToEntity();
            }

            throw new InvalidDataException();
        }

        public User InsertUser(User user)
        {
            var newUser = new UserModel().MapToModel(user);

            _context.User.Add(newUser);
            _context.SaveChanges();

            return user;
        }

        public User UpdateUser(User user)
        {
            var map = new UserModel().MapToModel(user);

            _context.User.Update(map);
            _context.SaveChanges();
            return user;
        }
    }
}
