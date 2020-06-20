using ToDoList.Server.Data;
using Microsoft.EntityFrameworkCore;
using ToDoList.Shared.Models;
using System.Threading.Tasks;

namespace ToDoList.Server.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ToDoListDbContext _dbContext;
        public UserRepository(ToDoListDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _dbContext.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Username == username);
        }

    }
}
