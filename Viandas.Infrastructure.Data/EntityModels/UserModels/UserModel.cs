using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class UserModel : IEntityModel<User, UserModel>
    {
        public  required string UserID { get; set; }
        public  required string UserName { get; set; }
        public  required string LastName { get; set; }
        public  required string UserNickname { get; set; }
        public  required  string EncryptedPassword { get; set; }
        public bool IsActivated { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public User.UserRol Rol { get; set; }

        public virtual required ICollection<OrderModel> Orders { get; set; }


        public static User MapToEntity(UserModel model)
        {
            return new User(id: model.UserID,
                            nickName: model.UserNickname!,
                            name: model.UserName!,
                            lastName: model.LastName!,
                            password: model.EncryptedPassword!,
                            isActivate: model.IsActivated,
                            birthDate: model.BirthDate,
                            creationDate: model.CreationDate,
                            rol:  model.Rol
                            );
        }

        public UserModel MapToModel(User entity)
        {
            return new UserModel
            {
                UserID = entity.GetId(),
                UserName = entity.Name,
                LastName = entity.LastName,
                UserNickname = entity.NickName,
                EncryptedPassword = entity.Password,
                IsActivated = entity.GetIsActivated(),
                Rol = entity.Rol,
                Orders = new List<OrderModel>()
            };
        }
    }
}
