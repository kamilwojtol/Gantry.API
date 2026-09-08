namespace Gantry.API.Models
{
    public class Kanban
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
