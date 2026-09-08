using Gantry.API.Utils;

namespace Gantry.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Author { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } = new DateTime();
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public TaskUtils.TaskStatusCode StatusCode { get; set; } = TaskUtils.TaskStatusCode.TO_DO;

    }
}
