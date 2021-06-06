using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using DataBaseCommunication;
using DataBaseCommunication.Models;

namespace StorageManagement.Services
{
    public class UserService
    {
        private readonly IDataFacade dataFacade;
        private readonly HashAlgorithm hasher = new SHA1CryptoServiceProvider();

        public UserService(IDataFacade dataFacade)
        {
            this.dataFacade = dataFacade;
        }

        public User Login(string username, string password)
        {
            var hashedPassword = HashPassword(password);
            var user = dataFacade.GetUser(username, hashedPassword);
            if (user is null)
            {
                throw new InvalidLoginException("Username or password is wrong");
            }
            return user;
        }

        private string HashPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);

            hasher.ComputeHash(data);

            return new ASCIIEncoding().GetString(data, 0, data.Length);
        }
    }

    [Serializable]
    internal class InvalidLoginException : Exception
    {
        public InvalidLoginException()
        {
        }

        public InvalidLoginException(string message) : base(message)
        {
        }

        public InvalidLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
