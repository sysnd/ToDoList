using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Shared.Models
{
    public class User : BaseModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(3, ErrorMessage = "Your username needs to be at least 3 characters long.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Your password needs to be at least 8 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string Salt { get; set; }

        public bool IsAdmin { get; set; }

        public List<Assignment> Tasks { get; set; }
    }
}
