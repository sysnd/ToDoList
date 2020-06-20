using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoList.Shared.Models;

namespace ToDoList.Client.Services.Users
{
    public interface IUserService
    {
        Task<HttpResponseMessage> Update(User user);

        Task<HttpResponseMessage> Delete(Guid userId);

        Task<List<User>> GetAll();
    }
}
