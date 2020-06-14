using ToDoList.Server.Data;
using TaskModel = ToDoList.Shared.Models.Task;

namespace ToDoList.Server.Repositories.Tasks
{
    public class TaskRepository : BaseRepository<TaskModel>, ITaskRepository
    {
        public TaskRepository(ToDoListDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
