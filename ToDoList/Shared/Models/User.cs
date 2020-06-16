using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Shared.Models
{
    public class User : BaseModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public List<Assignment> Tasks { get; set; }
    }
}
