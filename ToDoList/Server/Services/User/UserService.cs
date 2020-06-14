using System;
using System.Linq;
using ToDoList.Server.Repositories.User;
using UserModel = ToDoList.Shared.Models.User;
using Threading = System.Threading.Tasks;

namespace ToDoList.Server.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Threading.Task Create(UserModel entity)
        {
            await _userRepository.Create(entity);
        }

        public async Threading.Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }

        public IQueryable<UserModel> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Threading.Task<UserModel> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Threading.Task Update(UserModel entity)
        {
            await _userRepository.Update(entity);
        }
    }
}
