namespace ToDoList.Shared.Models.Responses
{
    public class LoginResponseMessage : GenericResponseMessage
    {
        public string Token { get; set; }

        public User User { get; set; }
    }
}
