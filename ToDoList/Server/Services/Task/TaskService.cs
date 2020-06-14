using ToDoList.Server.Repositories.Task;
using Threading = System.Threading.Tasks;
using TaskModel = ToDoList.Shared.Models.Task;
using System.Linq;
using System;

namespace ToDoList.Server.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Threading.Task Create(TaskModel entity)
        {
            await _taskRepository.Create(entity);
        }

        public async Threading.Task Delete(Guid id)
        {
            await _taskRepository.Delete(id);
        }

        public IQueryable<TaskModel> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public async Threading.Task<TaskModel> GetById(Guid id)
        {
            return await _taskRepository.GetById(id);
        }

        public async Threading.Task Update(TaskModel entity)
        {
            await _taskRepository.Update(entity);
        }
    }
}
