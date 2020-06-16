using System.Threading.Tasks;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUsername(string username);
    }
}
