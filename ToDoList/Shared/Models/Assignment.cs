using ToDoList.Shared.Enums;

namespace ToDoList.Shared.Models
{
    public class Assignment : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Effort { get; set; }

        public AssignmentStatus Status { get; set; }

        public User User { get; set; }
    }
}
