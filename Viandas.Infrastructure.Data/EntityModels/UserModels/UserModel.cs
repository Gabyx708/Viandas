using Viandas.Domain.Core.AggregatesModel.UserAggregate;

namespace Viandas.Infrastructure.Data.EntityModel
{
    public class UserModel
    {
        public required string UserID { get; set; }
        public required string UserName { get; set; }
        public required string LastName { get; set; }
        public required string UserNickname { get; set; }
        public required string EncryptedPassword { get; set; }
        public bool IsActivated { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public User.UserRol Rol { get; set; }

        public virtual required ICollection<OrderModel> Orders { get; set; }
    }
}
