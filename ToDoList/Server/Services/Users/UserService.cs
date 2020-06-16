using System;
using System.Linq;
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

        public async Task Create(User user)
        {
            await _userRepository.Create(user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }
    }
}
