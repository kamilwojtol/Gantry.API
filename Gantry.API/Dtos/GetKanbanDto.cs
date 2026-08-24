using Gantry.API.Interfaces;

namespace Gantry.API.Dtos
{
    public class GetKanbanDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ITask> Tasks { get; set; }
        public int TasksNumber => Tasks.Count;
    }
}
