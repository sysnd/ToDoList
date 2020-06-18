using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ToDoList.Server.Repositories.Users;
using ToDoList.Shared.Models;

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

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                await _userRepository.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                var currentUser = await _userRepository.GetById(user.Id);
                if (user.Username != currentUser.Username)
                {
                    await _userRepository.Update(user);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
