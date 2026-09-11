using Gantry.API.Interfaces;

namespace Gantry.API.Dtos
{
    public class EditKanbanDto
    {
        public string Title { get; set; }
        public List<Models.Task> Tasks { get; set; } = new List<Models.Task>();
        public int TasksNumber => Tasks.Count;
    }
}
