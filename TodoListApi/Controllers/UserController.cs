using Microsoft.AspNetCore.Mvc;
using TodoListApi.Interfeces;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUser userServices;
        public UserController(IUser userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet("GetUser")]
        public IActionResult Get()
        {
            return Ok(userServices.GetUsers());
        }
    }
}
