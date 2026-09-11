using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Interfaces
{
    public class ITask
    {
        public int Id { get; set;  }
        public string Name { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public string Author { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public TaskStatusCode Status { get; set; }
    }
}
