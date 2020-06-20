using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoList.Client.Services.Assignments;
using ToDoList.Client.Services.Users;

namespace ToDoList.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IAssignmentService, AssignmentService>();

            builder.Services.AddBlazoredModal(); 
            builder.Services.AddBlazoredToast();

            await builder.Build().RunAsync();
        }
    }
}
