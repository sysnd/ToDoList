using ToDoList.Server.Data;
using TaskModel = ToDoList.Shared.Models.Assignment;

namespace ToDoList.Server.Repositories.Assignments
{
    public class AssignmentRepository : BaseRepository<TaskModel>, IAssignmentRepository
    {
        public AssignmentRepository(ToDoListDbContext dbContext) : base(dbContext)
        {
                
        }
    }
}
