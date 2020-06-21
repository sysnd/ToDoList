using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Shared.Enums;

namespace ToDoList.Shared.Models
{
    public class Assignment : BaseModel
    {
        [Required(ErrorMessage = "Title is reqired")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Range(0, 100, ErrorMessage = "The estimated effort should be an integer between 0 and 100")]
        public int Effort { get; set; }

        public AssignmentStatus Status { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
