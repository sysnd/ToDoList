using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Server.Repositories.Users;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Responses;

namespace ToDoList.Server.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericResponseMessage> SignIn(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);
            var response = new GenericResponseMessage();

            if (user == null)
            {
                response.Message = "A user with these credentials does not exist.";
                response.IsSuccessful = false;
                return response;
            }
            var passByteArr = Encoding.UTF8.GetBytes(password);
            var saltByteArr = Convert.FromBase64String(user.Salt);
            var saltedHash = new Rfc2898DeriveBytes(passByteArr, saltByteArr, 1000);
            var hashedPass = Convert.ToBase64String(saltedHash.GetBytes(20));

            if (user.Password != hashedPass)
            {
                response.Message = "Your password is incorrect.";
                response.IsSuccessful = false;
                return response;
            }
            else
            {
                response.Message = "Successfully signed in.";
                response.IsSuccessful = true;
                return response;
            }
        }

        public async Task<GenericResponseMessage> SignUp(User user)
        {
            var response = new GenericResponseMessage();
            try
            {
                var existingUser = await _userRepository.GetByUsername(user.Username);

                if (existingUser != null)
                {
                    response.Message = "A user with these credentials already exists.";
                    response.IsSuccessful = false;
                    return response;
                }
                else
                {
                    byte[] salt = Guid.NewGuid().ToByteArray();
                    var saltedHash = new Rfc2898DeriveBytes(user.Password, salt, 1000);
                    var pass = saltedHash.GetBytes(20);
                    var passString = Convert.ToBase64String(pass);
                    var saltString = Convert.ToBase64String(saltedHash.Salt);

                    user.Salt = saltString;
                    user.Password = passString;
                    user.IsAdmin = false;

                    await _userRepository.Create(user);
                    response.Message = "Successfully signed up.";
                    response.IsSuccessful = true;
                    return response;
                }
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.Message = "Something went wrong. Please try again.";
                return response;
            }
        }
    }
}
