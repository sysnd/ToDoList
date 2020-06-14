using System;
using System.Linq;
using Threading = System.Threading.Tasks;
using Models = ToDoList.Shared.Models;

namespace ToDoList.Server.Repositories
{
    public interface IBaseRepository<T> where T : Models.BaseModel
    {
        IQueryable<T> GetAll();

        Threading.Task<T> GetById(Guid id);

        Threading.Task Create(T entity);

        Threading.Task Update(T entity);

        Threading.Task Delete(Guid id);
    }
}
