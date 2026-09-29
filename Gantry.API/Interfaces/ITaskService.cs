using Gantry.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Interfaces
{
    public interface ITaskService
    {
        public Task<List<Models.Task>>? GetAllTasks(int kanbanId);
        public Task<Models.Task>? GetTaskById(int kanbanId, int taskId);
        public Task<Models.Task> CreateTask(int kanbanId, PostTaskDto taskDto);
        public Task<Models.Task?> ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskStatusCode statusCode);
    }
}
