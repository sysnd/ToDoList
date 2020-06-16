using ToDoList.Server.Data;
using UserModel = ToDoList.Shared.Models.User;
using Threading = System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Server.Repositories.User
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        private readonly ToDoListDbContext _dbContext;
        public UserRepository(ToDoListDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Threading.Task<UserModel> GetByUsername(string username)
        {
            return await _dbContext.Set<UserModel>()
                .FirstOrDefaultAsync(e => e.Username == username);
        }

    }
}
