using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Server.Repositories.Users;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Responses;

namespace ToDoList.Server.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Create(User user)
        {
            try
            {
                await _userRepository.Create(user);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<GenericResponseMessage> Delete(Guid id)
        {
            var response = new GenericResponseMessage();

            try
            {
                await _userRepository.Delete(id);
                response.IsSuccessful = true;
                response.Message = "Successfully deleted user.";
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.Message = $"Could not delete user.";
            }

            return response;
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<GenericResponseMessage> Update(User user)
        {
            var response = new GenericResponseMessage();
            try
            {
                var currentUser = await _userRepository.GetById(user.Id);
                if (user.Username == currentUser.Username)
                {
                    await _userRepository.Update(user);
                    response.IsSuccessful = true;
                    response.Message = "Successfully updated user.";
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "You can not update the username field.";
                }
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.Message = $"Could not update user.";
            }

            return response;
        }
    }
}
