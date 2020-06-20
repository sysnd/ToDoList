using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Responses;

namespace ToDoList.Server.Services.Assignments
{
    public interface IAssignmentService
    {
        IQueryable<Assignment> GetAll();

        Task<Assignment> GetById(Guid id);

        Task<GenericResponseMessage> Create(Assignment assignment);

        Task<GenericResponseMessage> Update(Assignment assignment);

        Task<GenericResponseMessage> Delete(Guid id);
    }
}
