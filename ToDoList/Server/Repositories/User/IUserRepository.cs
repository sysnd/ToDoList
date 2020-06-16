using UserModel = ToDoList.Shared.Models.User;
using Threading = System.Threading.Tasks;

namespace ToDoList.Server.Repositories.User
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        Threading.Task<UserModel> GetByUsername(string username);
    }
}
