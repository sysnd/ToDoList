using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Services.Assignments
{
    public interface IAssignmentService
    {
        IQueryable<Assignment> GetAll();

        Task<Assignment> GetById(Guid id);

        Task<bool> Create(Assignment assignment);

        Task<bool> Update(Assignment assignment);

        Task<bool> Delete(Guid id);
    }
}
