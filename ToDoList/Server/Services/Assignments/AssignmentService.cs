using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Server.Repositories.Assignments;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Services.Assignments
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _taskRepository;

        public AssignmentService(IAssignmentRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task Create(Assignment assignment)
        {
            await _taskRepository.Create(assignment);
        }

        public async Task Delete(Guid id)
        {
            await _taskRepository.Delete(id);
        }

        public IQueryable<Assignment> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public async Task<Assignment> GetById(Guid id)
        {
            return await _taskRepository.GetById(id);
        }

        public async Task Update(Assignment assignment)
        {
            await _taskRepository.Update(assignment);
        }
    }
}
