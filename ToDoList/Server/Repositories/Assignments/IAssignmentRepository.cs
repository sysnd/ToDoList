using TaskModel = ToDoList.Shared.Models.Assignment;

namespace ToDoList.Server.Repositories.Assignments
{
    public interface IAssignmentRepository : IBaseRepository<TaskModel>
    {
    }
}
