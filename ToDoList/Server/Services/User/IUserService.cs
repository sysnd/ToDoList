using System;
using System.Linq;
using UserModel = ToDoList.Shared.Models.User;
using Threading = System.Threading.Tasks;

namespace ToDoList.Server.Services.User
{
    public interface IUserService
    {
        IQueryable<UserModel> GetAll();

        Threading.Task<UserModel> GetById(Guid id);

        Threading.Task Create(UserModel entity);

        Threading.Task Update(UserModel entity);

        Threading.Task Delete(Guid id);
    }
}
