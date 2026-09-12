using Microsoft.AspNetCore.Mvc;
using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Interfaces
{
    public interface ITaskService
    {
        public List<Models.Task>? GetAllTasks(int kanbanId);
        public Models.Task? GetTaskById(int kanbanId, int taskId);
        public Task<Models.Task?> ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskStatusCode statusCode);
    }
}
