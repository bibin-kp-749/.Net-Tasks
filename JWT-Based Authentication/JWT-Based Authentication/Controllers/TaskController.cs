using JWT_Based_Authentication.Model;
using JWT_Based_Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Based_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices taskServices;
        public TaskController(ITaskServices taskServices)
        {
            this.taskServices = taskServices;
        }

        [Authorize]
        [HttpGet("ViewTasks")]
        public IEnumerable<Tasks> ViewTasks()
        {
            return taskServices.ViewTasks();
        }

        [Authorize]
        [HttpPost("AddTask")]
        public IActionResult AddTasks(Tasks task)
        {
            return Ok(taskServices.AddTasks(task));
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("UpdateTask")]
        public IEnumerable<Tasks> UpdateTasks(Tasks task)
        {
            return taskServices.UpdateTasks(task);
        }

        [Authorize(Roles =Role.Admin)]
        [HttpDelete("DeleteTask")]
        public IEnumerable<Tasks> DeleteTasks(int id)
        {
            return taskServices.DeleteTasks(id);
        }
    }
}
