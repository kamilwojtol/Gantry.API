using Gantry.API.Interfaces;

namespace Gantry.API.Dtos
{
    public class EditKanbanDto
    {
        public string Title { get; set; }
        public List<ITask> Tasks { get; set; } = new List<ITask>();
        public int TasksNumber => Tasks.Count;
    }
}
