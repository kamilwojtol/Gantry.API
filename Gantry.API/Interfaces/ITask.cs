using static Gantry.API.Utils.TaskUtils;

namespace Gantry.API.Interfaces
{
    public class ITask
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public TaskStatusCode Status { get; set; }
    }
}
