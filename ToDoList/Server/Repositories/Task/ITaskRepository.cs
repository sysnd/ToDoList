using TaskModel = ToDoList.Shared.Models.Task;

namespace ToDoList.Server.Repositories.Task
{
    public interface ITaskRepository : IBaseRepository<TaskModel>
    {
    }
}
