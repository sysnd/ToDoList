using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoList.Client.Infrastructure;
using ToDoList.Shared.Models;
using ToDoList.Shared.Models.Requests;
using ToDoList.Shared.Models.Responses;
using ToDoList.Shared.Utils;

namespace ToDoList.Client.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResponseMessage> Login(UserLoginRequest user)
        {
            var result = await _httpClient.PostAsJsonAsync("auth/signin", user);
            var responseObj = await JsonUtils.GetObjectFromHttpResponse<LoginResponseMessage>(result);

            if (responseObj.IsSuccessful)
            {
                var name = responseObj.User.FirstName + " " + responseObj.User.LastName;
                var role = responseObj.User.IsAdmin ? "Admin" : "User";

                await _localStorage.SetItemAsync("authToken", responseObj.Token);

                ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(name, role);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", responseObj.Token);
            }

            return responseObj;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<HttpResponseMessage> Register(User user)
        {
            var result = await _httpClient.PostAsJsonAsync("auth/signup", user);
            return result;
        }
    }
}
