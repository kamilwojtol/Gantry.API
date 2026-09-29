using System.ComponentModel.DataAnnotations;

namespace Gantry.API.Dtos
{
    public class EditKanbanDto
    {
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public List<Models.Task> Tasks { get; set; } = new List<Models.Task>();
        public int TasksNumber => Tasks.Count;
    }
}
