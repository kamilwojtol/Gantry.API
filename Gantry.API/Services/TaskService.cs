using Gantry.API.Interfaces;
using Gantry.API.Store;
using Gantry.API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Gantry.API.Services
{
    public class TaskService : ITaskService
    {
        readonly GantryStore _gantryStore;

        public TaskService(GantryStore gantryStore)
        {
            _gantryStore = gantryStore;
        }

        public ITask? ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskUtils.TaskStatusCode statusCode)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return null;
            }

            var foundTask = foundKanban.Tasks.FirstOrDefault((task) =>
            {
                return task.Id == taskId;
            });

            if (foundTask == null)
            {
                return null;
            }

            foundTask.Status = statusCode;

            return foundTask;
        }

        public List<ITask>? GetAllTasks(int kanbanId)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return null;
            }

            return foundKanban.Tasks;
        }

        public ITask? GetTaskById(int kanbanId, int taskId)
        {
            var foundKanban = _gantryStore.kanbanStore.FirstOrDefault((kanban) =>
            {
                return kanban.Id == kanbanId;
            });

            if (foundKanban == null)
            {
                return null;
            }

            var foundTask = foundKanban.Tasks.FirstOrDefault((task) =>
            {
                return task.Id == taskId;
            });

            if (foundTask == null)
            {
                return null;
            }

            return foundTask;
        }
    }
}
