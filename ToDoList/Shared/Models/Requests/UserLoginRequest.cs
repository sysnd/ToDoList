using System.ComponentModel.DataAnnotations;

namespace ToDoList.Shared.Models.Requests
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
