using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoList.Shared.Models;

namespace ToDoList.Client.Services.Assignments
{
    public interface IAssignmentService
    {
        Task<HttpResponseMessage> Create(Assignment assignment);

        Task<HttpResponseMessage> Update(Assignment assignment);

        Task<HttpResponseMessage> Delete(Guid assignmentId);

        Task<List<Assignment>> GetAll();
    }
}
