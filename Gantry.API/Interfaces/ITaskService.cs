using Gantry.API.Store;
using Microsoft.AspNetCore.Mvc;
using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Interfaces
{
    public interface ITaskService
    {
        public List<ITask>? GetAllTasks(int kanbanId);
        public ITask? GetTaskById(int kanbanId, int taskId);
        public ITask? ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskStatusCode statusCode);
    }
}
