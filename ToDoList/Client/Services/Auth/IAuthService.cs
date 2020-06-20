using System.Net.Http;
using System.Threading.Tasks;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Requests;
using ToDoList.Shared.Models.Responses;

namespace ToDoList.Client.Services.Auth
{
    public interface IAuthService
    {
        Task<HttpResponseMessage> Register(User user);

        Task<LoginResponseMessage> Login(UserLoginRequest user);

        Task Logout();
    }
}
