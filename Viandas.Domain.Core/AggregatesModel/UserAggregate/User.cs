namespace Viandas.Domain.Core.AggregatesModel.UserAggregate
{
    public class User
    {
        public string Id { get; private set; }
        public string NickName { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public bool IsActivate { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreationDate { get; private set; }
        public UserRol Rol { get; private set; }

        private UserID _userID;
        private UserPassword _userPassword;

        public enum UserRol
        {
            Admin,
            Normal
        }

        public User(string id, string nickName, string name, string lastName, string plainPassword, DateTime birthDate)
        {
            _userID = new UserID(id);
            Id = _userID.Value;
            NickName = nickName;
            Name = name;
            LastName = lastName;
            _userPassword = new UserPassword(plainPassword);
            Password = _userPassword.Value;
            BirthDate = birthDate;

            Rol = UserRol.Normal;
        }

        public void SetRol(UserRol rol)
        {
            this.Rol = rol;
        }

        public string GetFullName()
        {
            return $"{Name} {LastName}";
        }

        public bool GetIsActivated()
        {
            return IsActivate;
        }

        public void ChangePassword(string password)
        {
            _userPassword = new UserPassword(password);
            Password = _userPassword.Value;
        }
        public void ResetPassword()
        {
            _userPassword = new UserPassword(Id);
            Password = _userPassword.Value;
        }
    }
}
