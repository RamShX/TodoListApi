using Microsoft.AspNetCore.Mvc;
using TodoListApi.Interfeces;
using TodoListApi.Models;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TodoTasksController : ControllerBase
    {
        private ITask taskServices;

        public TodoTasksController(ITask task)
        {
            this.taskServices = task;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = taskServices.GetTasks();
            if (tasks == null || !tasks.Any())
                return NotFound(new { message = "No se encontraron tareas." });
            return Ok(new {message = "Tareas obtenidas con éxito", data = tasks});
        }

        [HttpGet("user/{UserId}")]
        public IActionResult GetByUserId(int UserId)
        {
            var tasksUser = taskServices.GetTaskByIdUser(UserId);
            
            if(tasksUser == null || !tasksUser.Any())
                return NotFound(new { message = "No se encontraron tareas para este usuario." });

            return Ok(new {message = $"Tareas obtenidas de este usuario {tasksUser} fue éxitoso", data = tasksUser });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = taskServices.GetTaskById(id);
            if (task == null)
            {
                return NotFound(new {message = $"Tarea con {id} no fue encontrado."});
            }

            return Ok(new {message = $"Tarea recuperada correctamente!!", data = task});
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoTasks task)
        {
            var CreatedTask = taskServices.CreateTask(task);
            return CreatedAtAction(nameof(GetById), new { id = CreatedTask.Id }, new
            {
                message = "La tarea se creó correctamente",
                data = CreatedTask
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoTasks task)
        {
            if (id != task.Id)
                return BadRequest(new { message = $"La tarea hay un desajuste de {id}"});
          
            var UpdatedTask = taskServices.UpdateTask(task);

            if (UpdatedTask == null)
                return NotFound(new { message = $"Tarea con el {id} no fue encontrado o ya está eliminado para ser actualizado." });

            return Ok(new {message = $"La tarea se actualizó correctamente!!", data = UpdatedTask});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = taskServices.DeleteTask(id);

            if (!result)
                return NotFound(new {message = $"Tarea con el {id} no fue encontrado o ya está eliminado."});
            
            return Ok(new {message = $"La tarae con {id} fue eliminada correctamente!! "});
        }
    }
}
