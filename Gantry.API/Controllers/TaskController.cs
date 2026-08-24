using Microsoft.AspNetCore.Mvc;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/{kanbanId}/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet("getTasks")]
        public ActionResult GetTasks(int kanbanId)
        {
            return Ok("Everything is all right!");
        }

        [HttpGet("getTask/{taskId}")]
        public ActionResult GetTaskById(int kanbanId, int taskId)
        {
            return Ok("Everything is all right!");
        }

    }
}
