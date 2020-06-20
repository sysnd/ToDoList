using System.Threading.Tasks;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Responses;

namespace ToDoList.Server.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseMessage> SignIn(string username, string password);

        Task<GenericResponseMessage> SignUp(User user);
    }
}
