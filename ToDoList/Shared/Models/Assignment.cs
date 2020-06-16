using System.Threading.Tasks;

namespace ToDoList.Shared.Models
{
    public class Assignment : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Effort { get; set; }

        public TaskStatus Status { get; set; }

        public User User { get; set; }
    }
}
