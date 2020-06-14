using System;
using System.Threading.Tasks;

namespace ToDoList.Shared.Models
{
    public class Task
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Effort { get; set; }

        public TaskStatus Status { get; set; }
    }
}
