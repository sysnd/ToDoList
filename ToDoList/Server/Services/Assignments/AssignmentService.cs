using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Server.Repositories.Assignments;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Responses;

namespace ToDoList.Server.Services.Assignments
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<GenericResponseMessage> Create(Assignment assignment)
        {
            var response = new GenericResponseMessage();

            try
            {
                await _assignmentRepository.Create(assignment);
                response.IsSuccessful = true;
                response.Message = "Successfully created assignment.";
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.Message = $"Could not delete assignment.";
            }

            return response;
        }

        public async Task<GenericResponseMessage> Delete(Guid id)
        {
            var response = new GenericResponseMessage();

            try
            {
                await _assignmentRepository.Delete(id);
                response.IsSuccessful = true;
                response.Message = "Successfully deleted assignment.";
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.Message = $"Could not delete assignment.";
            }

            return response;
        }

        public IQueryable<Assignment> GetAll()
        {
            return _assignmentRepository.GetAll();
        }

        public async Task<Assignment> GetById(Guid id)
        {
            return await _assignmentRepository.GetById(id);
        }

        public async Task<GenericResponseMessage> Update(Assignment assignment)
        {
            var response = new GenericResponseMessage();
            try
            {
                await _assignmentRepository.Update(assignment);
                response.IsSuccessful = true;
                response.Message = "Successfully updated assignment.";
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.Message = $"Could not update assignment.";
            }

            return response;
        }
    }
}
