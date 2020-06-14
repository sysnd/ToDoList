using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.Server.Data;
using ToDoList.Server.Repositories;
using ToDoList.Server.Repositories.Task;
using ToDoList.Server.Repositories.User;
using ToDoList.Server.Services.Auth;
using ToDoList.Server.Services.Task;
using ToDoList.Server.Services.User;

namespace ToDoList.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ToDoListDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
