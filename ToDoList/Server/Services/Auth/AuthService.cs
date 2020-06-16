﻿using ToDoList.Server.Common.Responses;
using ToDoList.Server.Repositories.User;
using Threading = System.Threading.Tasks;
using UserModel = ToDoList.Shared.Models.User;

namespace ToDoList.Server.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Threading.Task<MessageResponse> SignIn(string username, string password)
        {
            var user = await _userRepository.GetByUsername(username);
            var response = new MessageResponse();
            if (user == null)
            {
                response.Message = "A user with these credentials does not exist.";
                response.Success = false;
                return response;
            }
            else if (user.Password != password)
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

        public async Threading.Task<MessageResponse> SignUp(UserModel user)
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
                await _userRepository.Create(user);
                response.Message = "Successfully signed up.";
                response.Success = true;
                return response;
            }
        }
    }
}
