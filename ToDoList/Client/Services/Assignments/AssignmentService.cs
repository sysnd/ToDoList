using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoList.Shared.Models;

namespace ToDoList.Client.Services.Assignments
{
    public class AssignmentService : IAssignmentService
    {
        private readonly HttpClient _httpClient;
        public AssignmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Create(Assignment assignment)
        {
            var result = await _httpClient.PostAsJsonAsync("assignment", assignment);
            return result;
        }

        public async Task<HttpResponseMessage> Delete(Guid assignmentId)
        {
            var result = await _httpClient.DeleteAsync($"assignment/{assignmentId}");
            return result;
        }

        public async Task<List<Assignment>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Assignment>>($"assignment");
            return result;
        }

        public async Task<HttpResponseMessage> Update(Assignment assignment)
        {
            var result = await _httpClient.PutAsJsonAsync("assignment", assignment);
            return result;
        }
    }
}
