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

        public string Name => _name;
        public string LastName => _lastName;
        public string NickName => _nickName;
        public string Password => _password;
        public DateTime CreationDate => _creationDate;
        public DateTime BirthDate => _birthDate;
        public UserRol Rol => _rol;

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
            _creationDate = DateTime.Now;

            _isActivate = true;

            _rol = UserRol.Normal;
        }

        public User(string id,
                    string nickName,
                    string name,
                    string lastName,
                    string password,
                    bool isActivate,
                    DateTime birthDate,
                    DateTime creationDate,
                    UserRol rol)
        {
            _id = id;
            _nickName = nickName;
            _name = name;
            _lastName = lastName;
            _password = password;
            _isActivate = isActivate;
            _birthDate = birthDate;
            _creationDate = creationDate;
            _rol = rol;

            _userID = new UserID(id);
            _userPassword = new UserPassword(password);
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

        public string GetId()
        {
            return _id;
        }

        public void Disable()
        {
            _isActivate = false;
        }

        public void ChangePassword(string password)
        {
            _userPassword = new UserPassword(password);
            _password = _userPassword.Value;
        }
        public void ResetPassword()
        {
            _userPassword = new UserPassword(_id);
            _password = _userPassword.Value;
        }
    }
}
