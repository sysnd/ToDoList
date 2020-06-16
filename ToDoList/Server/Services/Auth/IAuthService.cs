using ToDoList.Server.Common.Responses;
using Threading = System.Threading.Tasks;
using UserModel = ToDoList.Shared.Models.User;

namespace ToDoList.Server.Services.Auth
{
    public interface IAuthService
    {
        Threading.Task<MessageResponse> SignIn(string username, string password);

        Threading.Task<MessageResponse> SignUp(UserModel user);
    }
}
