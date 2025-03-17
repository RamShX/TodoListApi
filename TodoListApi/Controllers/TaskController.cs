using Microsoft.AspNetCore.Mvc;
using TodoListApi.Interfeces;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private ITask taskServices;

        public TaskController(ITask task)
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
