namespace Viandas.Domain.Core.AggregatesModel.UserAggregate
{
    public class User
    {
        private string _id;
        private string _nickName;
        private string _name;
        private string _lastName;
        private string _password;
        private bool _isActivate;
        private DateTime _birthDate;
        private DateTime _creationDate;
        private UserRol _rol;

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
            _id = _userID.Value;
            _nickName = nickName;
            _name = name;
            _lastName = lastName;
            _userPassword = new UserPassword(plainPassword);
            _password = _userPassword.Value;
            _birthDate = birthDate;

            _rol = UserRol.Normal;
        }

        public void SetRol(UserRol rol)
        {
            this._rol = rol;
        }

        public string GetFullName()
        {
            return $"{_name} {_lastName}";
        }

        public bool GetIsActivated()
        {
            return _isActivate;
        }

        public void ChangePassword(string password)
        {
            _userPassword = new UserPassword(password);
            _password = _userPassword.Value;
        }
        public void ResetPassword()
        {
            _userPassword = new UserPassword(_userID);
            _password = _userPassword.Value;
        }
    }
}
