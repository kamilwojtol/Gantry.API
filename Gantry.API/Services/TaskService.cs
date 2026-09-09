using Gantry.API.Data;
using Gantry.API.Interfaces;
using Gantry.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Gantry.API.Services
{
    public class TaskService : ITaskService
    {
        readonly AppDbContext _dbContext;

        public TaskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Models.Task? ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskUtils.TaskStatusCode statusCode)
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);

            if (foundKanban == null)
            {
                return null;
            }

            var foundTask = _dbContext.Tasks.Find(taskId);

            if (foundTask == null)
            {
                return null;
            }

            foundTask.StatusCode = statusCode;

            return foundTask;
        }

        public List<Models.Task>? GetAllTasks(int kanbanId)
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);

            if (foundKanban == null)
            {
                return null;
            }

            return foundKanban.Tasks;
        }

        public Models.Task? GetTaskById(int kanbanId, int taskId)
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);

            if (foundKanban == null)
            {
                return null;
            }

            var foundTask = _dbContext.Tasks.Find(taskId);

            if (foundTask == null)
            {
                return null;
            }

            return foundTask;
        }
    }
}
