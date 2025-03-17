using Microsoft.AspNetCore.Mvc;
using TodoListApi.Interfeces;

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
    }
}
