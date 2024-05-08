using ASPNETAPIDay1.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNETAPIDay1.DTOs
{
    public class ToDoTaskDTOs
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

    }
}
