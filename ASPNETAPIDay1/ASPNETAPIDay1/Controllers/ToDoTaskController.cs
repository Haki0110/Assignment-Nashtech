using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ASPNETAPIDay1.Model;
using ASPNETAPIDay1.Services;
using ASPNETAPIDay1.DTOs;

namespace ASPNETAPIDay1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _taskService;

        public ToDoTaskController(IToDoTaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] ToDoTaskDTOs taskDTO)
        {
            _taskService.Create(taskDTO);
            return Ok();
        }

        [HttpPost("bulk")]
        public IActionResult CreateBulkTasks([FromBody] List<ToDoTaskDTOs> tasksDTO)
        {
            _taskService.CreateBulk(tasksDTO);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(Guid id)
        {
            var task = _taskService.GetSpeTask(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            _taskService.Delete(id);
            return NoContent();
        }

        [HttpDelete("bulk")]
        public IActionResult DeleteBulkTasks([FromBody] List<Guid> ids)
        {
            _taskService.DeleteMultiple(ids);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult EditTask(Guid id, [FromBody] ToDoTask toDoTask)
        {
            var existingTask = _taskService.GetSpeTask(id);
            if (existingTask == null)
                return NotFound();

            existingTask.Title = toDoTask.Title;
            existingTask.IsCompleted = toDoTask.IsCompleted;

            _taskService.EditTitle(existingTask);
            return NoContent();
        }
    }
}
