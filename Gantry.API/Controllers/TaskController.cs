using Gantry.API.Interfaces;
using Gantry.API.Store;
using Microsoft.AspNetCore.Mvc;
using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Controllers
{
    [Route("/api/kanban/{kanbanId}/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("getTasks")]
        public ActionResult<List<ITask>> GetAllTasks(int kanbanId)
        {
            var allTasks = _taskService.GetAllTasks(kanbanId);

            if (allTasks == null)
            {
                return NotFound();
            }

            return Ok(allTasks);
        }

        [HttpGet("getTask/{taskId}")]
        public ActionResult<ITask> GetTaskById(int kanbanId, int taskId)
        {
            var singleIdTask = _taskService.GetTaskById(kanbanId, taskId);

            if (singleIdTask == null)
            {
                return NotFound();
            }

            return Ok(singleIdTask);
        }

        [HttpPatch("changeTaskStatus/{taskId}")]
        public ActionResult<ITask> ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskStatusCode statusCode)
        {
            var taskWithChangedStatus = _taskService.ChangeTaskStatus(kanbanId, taskId, statusCode);

            if (taskWithChangedStatus == null)
            {
                return NotFound();
            }

            return Ok(taskWithChangedStatus);
        }

    }
}
