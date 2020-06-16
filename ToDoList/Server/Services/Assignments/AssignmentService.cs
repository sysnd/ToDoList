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

        public async Task<bool> Create(Assignment assignment)
        {
            try
            {
                await _taskRepository.Create(assignment);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                await _taskRepository.Delete(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IQueryable<Assignment> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public async Task<Assignment> GetById(Guid id)
        {
            return await _taskRepository.GetById(id);
        }

        public async Task<bool> Update(Assignment assignment)
        {
            try
            {
                await _taskRepository.Update(assignment);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
