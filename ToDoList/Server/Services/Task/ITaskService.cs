using System;
using System.Linq;
using TaskModel = ToDoList.Shared.Models.Task;
using Threading = System.Threading.Tasks;

namespace ToDoList.Server.Services.Task
{
    public interface ITaskService
    {
        IQueryable<TaskModel> GetAll();

        Threading.Task<TaskModel> GetById(Guid id);

        Threading.Task Create(TaskModel entity);

        Threading.Task Update(TaskModel entity);

        Threading.Task Delete(Guid id);
    }
}
