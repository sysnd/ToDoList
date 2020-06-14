using ToDoList.Server.Data;
using UserModel = ToDoList.Shared.Models.User;

namespace ToDoList.Server.Repositories.User
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(ToDoListDbContext dbContext) : base(dbContext)
        {

        }
    }
}
