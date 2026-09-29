using Gantry.API.Dtos;
using Gantry.API.Interfaces;
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
        async public Task<ActionResult<List<ITask>>> GetAllTasks(int kanbanId)
        {
            var allTasks = await _taskService.GetAllTasks(kanbanId);

            if (allTasks == null)
            {
                return NotFound();
            }

            return Ok(allTasks);
        }

        [HttpGet("getTask/{taskId}")]
        async public Task<ActionResult<ITask>> GetTaskById(int kanbanId, int taskId)
        {
            var singleIdTask = await _taskService.GetTaskById(kanbanId, taskId);

            if (singleIdTask == null)
            {
                return NotFound();
            }

            return Ok(singleIdTask);
        }

        [HttpPost("createTask/")]
        async public Task<ActionResult<Models.Task>> CreateTask(int kanbanId, PostTaskDto newTask)
        {
            if (newTask == null)
            {
                return BadRequest();
            }

            var task = await _taskService.CreateTask(kanbanId, newTask);
            return Ok(task);
        }

        [HttpPatch("changeTaskStatus/{taskId}")]
        async public Task<ActionResult<ITask>> ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskStatusCode statusCode)
        {
            var taskWithChangedStatus = await _taskService.ChangeTaskStatus(kanbanId, taskId, statusCode);

            if (taskWithChangedStatus == null)
            {
                return NotFound();
            }

            return Ok(taskWithChangedStatus);
        }

    }
}
