using System.Threading.Tasks;
using ToDoList.Server.Common.Responses;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Services.Auth
{
    public interface IAuthService
    {
        Task<MessageResponse> SignIn(string username, string password);

        Task<MessageResponse> SignUp(User user);
    }
}
