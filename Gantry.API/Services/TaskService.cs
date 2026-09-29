using Gantry.API.Data;
using Gantry.API.Dtos;
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

        async public Task<Models.Task> ChangeTaskStatus(int kanbanId, int taskId, [FromQuery] TaskUtils.TaskStatusCode statusCode)
        {
            var foundKanban = await _dbContext.KanbanBoards.FindAsync(kanbanId);

            if (foundKanban == null)
            {
                return null;
            }

            var taskFromFoundKanban = foundKanban.Tasks.FirstOrDefault((task) => task.Id == taskId);

            if (taskFromFoundKanban == null)
            {
                return null;
            } else
            {
                taskFromFoundKanban.StatusCode = statusCode;
            }

            await _dbContext.SaveChangesAsync();

            return taskFromFoundKanban;
        }

        async public Task<Models.Task> CreateTask(int kanbanId, PostTaskDto taskDto)
        {
            var foundKanban = _dbContext.KanbanBoards.Find(kanbanId);

            if (foundKanban == null)
            {
                return null;
            }

            Models.Task newTask = new Models.Task()
            {
                Name = taskDto.Name,
                StatusCode = TaskUtils.TaskStatusCode.TO_DO,
                Author = taskDto.Author,
                CreatedAt = DateTime.UtcNow,
                Deadline = taskDto.Deadline,
                Description = taskDto.Description,
            };

            foundKanban.Tasks.Add(newTask);

            await _dbContext.SaveChangesAsync();

            return newTask;
        }

        async public Task<List<Models.Task>> GetAllTasks(int kanbanId)
        {
            var foundKanban = await _dbContext.KanbanBoards.FindAsync(kanbanId);

            if (foundKanban == null)
            {
                return null;
            }

            return foundKanban.Tasks;
        }

        async public Task<Models.Task> GetTaskById(int kanbanId, int taskId)
        {
            var foundKanban = await _dbContext.KanbanBoards.FindAsync(kanbanId);

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
