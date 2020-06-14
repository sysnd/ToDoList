using UserModel = ToDoList.Shared.Models.User;

namespace ToDoList.Server.Repositories.User
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        
    }
}
