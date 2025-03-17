using Microsoft.AspNetCore.Mvc;
using TodoListApi.Interfeces;
using TodoListApi.Models;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTasksController : ControllerBase
    {
        private ITask taskServices;

        public TodoTasksController(ITask task)
        {
            this.taskServices = task;
        }

        [HttpGet("GetTasks")]
        public IActionResult Get()
        {
            return Ok(taskServices.GetTasks());
        }

        [HttpGet("GetTaskByUserId/{UserId}")]
        public IActionResult GetByUserId(int UserId)
        {
            return Ok(taskServices.GetTaskByIdUser(UserId));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = taskServices.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public IActionResult Create([FromBody] TodoTasks task)
        {
            var CreatedTask = taskServices.CreateTask(task);
            return CreatedAtAction(nameof(GetById), new { id = CreatedTask.Id }, CreatedTask);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoTasks task)
        {
            if (id != task.Id)
                return BadRequest();
          
            var UpdatedTask = taskServices.UpdateTask(task);

            if (UpdatedTask == null)
                return NotFound();
            
            return Ok(UpdatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = taskServices.DeleteTask(id);

            if (!result)
                return NoContent();
            
            return NotFound();
        }
    }
}
