using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Services.Users
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        Task<User> GetById(Guid id);

        Task Create(User user);

        Task Update(User user);

        Task Delete(Guid id);
    }
}
