using Gantry.API.Store;
using Microsoft.AspNetCore.Mvc;
using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/{kanbanId}/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly GantryStore _gantryStore;

        public TaskController(GantryStore gantryStore)
        {
            _gantryStore = gantryStore;
        }

        [HttpGet("getTasks")]
        public ActionResult GetAllTasks(int kanbanId)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return NotFound();
            }

            return Ok(foundKanban.Tasks);
        }

        [HttpGet("getTask/{taskId}")]
        public ActionResult GetTaskById(int kanbanId, int taskId)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return NotFound();
            }

            var foundTask = foundKanban.Tasks.FirstOrDefault((task) =>
            {
                return task.Id == taskId;
            });

            if (foundTask == null)
            {
                return NotFound();
            }

            return Ok(foundTask);
        }

        [HttpPatch("changeTaskStatus/{taskId}")]
        public ActionResult ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskStatusCode statusCode)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return NotFound();
            }

            var foundTask = foundKanban.Tasks.FirstOrDefault((task) =>
            {
                return task.Id == taskId;
            });

            if (foundTask == null)
            {
                return NotFound();
            }

            foundTask.Status = statusCode;

            return Ok(foundTask);
        }

    }
}
