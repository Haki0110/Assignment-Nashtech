using ASPNETAPIDay1.DTOs;
using ASPNETAPIDay1.Model;

namespace ASPNETAPIDay1.Services
{
    public interface IToDoTaskService
    {
        public void Create(ToDoTaskDTOs toDoTaskDTOs);
        public void CreateBulk(List<ToDoTaskDTOs> toDoTaskDTOsList);
        public List<ToDoTask> GetAll();
        public ToDoTask GetSpeTask(Guid id);
        public void Delete(Guid id);
        public void DeleteMultiple(List<Guid> ids);
        public void EditTitle(ToDoTask toDoTask);
    }
}
