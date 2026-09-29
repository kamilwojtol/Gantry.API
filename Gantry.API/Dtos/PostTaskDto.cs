using System.ComponentModel.DataAnnotations;

namespace Gantry.API.Dtos
{
    public class PostTaskDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        public string Author { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
