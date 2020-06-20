using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Responses;

namespace ToDoList.Server.Services.Users
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        Task<User> GetById(Guid id);

        Task<bool> Create(User user);

        Task<GenericResponseMessage> Update(User user);

        Task<bool> Delete(Guid id);
    }
}
