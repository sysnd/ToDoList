using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Shared.Models;

namespace ToDoList.Server.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();

        Task<T> GetById(Guid id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(Guid id);
    }
}
