using Viandas.Domain.Core.AggregatesModel.UserAggregate;
using Viandas.Infrastructure.Data.EntityModels;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class UserModel : IEntityModel<User, UserModel>
    {
        public string UserID { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserNickname { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;
        public bool IsActivated { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public User.UserRol Rol { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; } = new List<OrderModel>();


        public User MapToEntity()
        {
            return new User(id: UserID,
                            nickName: UserNickname!,
                            name: UserName!,
                            lastName: LastName!,
                            password: EncryptedPassword!,
                            isActivate: IsActivated,
                            birthDate: BirthDate,
                            creationDate: CreationDate,
                            rol:  Rol
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
                BirthDate = entity.BirthDate.ToUniversalTime(),
                CreationDate = entity.CreationDate.ToUniversalTime(),
                Rol = entity.Rol,
                Orders = new List<OrderModel>()
            };
        }
    }
}
