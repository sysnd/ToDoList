using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ToDoList.Server.Common.Responses;
using ToDoList.Server.Repositories.Users;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<MessageResponse> SignIn(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);

            var passByteArr = Convert.FromBase64String(password);
            var saltByteArr = Convert.FromBase64String(user.Salt);
            var saltedHash = new Rfc2898DeriveBytes(passByteArr, saltByteArr, 1000);
            var hashedPass = Convert.ToBase64String(saltedHash.GetBytes(20));

            var response = new MessageResponse();
            if (user == null)
            {
                response.Message = "A user with these credentials does not exist.";
                response.Success = false;
                return response;
            }
            else if (user.Password != hashedPass)
            {
                response.Message = "Your password is incorrect.";
                response.Success = false;
                return response;
            }
            else
            {
                response.Message = "Successfully signed in.";
                response.Success = true;
                return response;
            }
        }

        public async Task<MessageResponse> SignUp(User user)
        {
            var response = new MessageResponse();
            var existingUser = await _userRepository.GetByUsername(user.Username);

            if (existingUser != null)
            {
                response.Message = "A user with these credentials already exists.";
                response.Success = false;
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
                response.Success = true;
                return response;
            }
        }
    }
}
