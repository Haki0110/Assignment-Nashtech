using System;
using System.Collections.Generic;
using System.Linq;
using ASPNETAPIDay1.DTOs;
using ASPNETAPIDay1.Model;

namespace ASPNETAPIDay1.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private List<ToDoTask> todo = new List<ToDoTask>();

        public void Create(ToDoTaskDTOs toDoTaskDTOs)
        {
            if (toDoTaskDTOs != null)
            {
                ToDoTask newTask = new ToDoTask
                {
                    id = Guid.NewGuid(), // Generate a new unique id
                    Title = toDoTaskDTOs.Title,
                    IsCompleted = true // or set it based on DTOs
                };

                todo.Add(newTask);
            }
        }

        public void CreateBulk(List<ToDoTaskDTOs> toDoTaskDTOsList)
        {
            foreach (var dto in toDoTaskDTOsList)
            {
                Create(dto);
            }
        }

        public List<ToDoTask> GetAll()
        {
            return todo;
        }

        public ToDoTask GetSpeTask(Guid id)
        {
            return todo.FirstOrDefault(t => t.id == id);
        }

        public void Delete(Guid id)
        {
            var deleteTask = todo.FirstOrDefault(t => t.id == id);
            if (deleteTask != null)
            {
                todo.Remove(deleteTask);
            }
        }

        public void DeleteMultiple(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                Delete(id);
            }
        }

        public void EditTitle(ToDoTask toDoTask)
        {
            var editTask = todo.FirstOrDefault(t => t.id == toDoTask.id);
            if (editTask != null)
            {
                editTask.Title = toDoTask.Title;
                editTask.IsCompleted = toDoTask.IsCompleted;
            }
        }
    }
}
