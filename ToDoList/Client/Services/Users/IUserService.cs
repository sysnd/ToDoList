using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Requests;

namespace ToDoList.Client.Services.Users
{
    public interface IUserService
    {
        Task<HttpResponseMessage> Login(UserLoginRequest user);

        Task<HttpResponseMessage> Register(User user);

        Task<HttpResponseMessage> Update(User user);

        Task<HttpResponseMessage> Delete(Guid userId);

        Task<List<User>> GetAll();
    }
}
