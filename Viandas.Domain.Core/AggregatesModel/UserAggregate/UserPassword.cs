using System.Security.Cryptography;
using System.Text;

namespace Viandas.Domain.Core.AggregatesModel.UserAggregate
{
    internal class UserPassword
    {
        public string Value { get; private set; }

        public UserPassword(string password)
        {
            Value = Encrypt(password);
        }

        private string Encrypt(string plainPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
