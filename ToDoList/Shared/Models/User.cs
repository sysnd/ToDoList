using System.Collections.Generic;

namespace ToDoList.Shared.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
