namespace Gantry.API.Dtos
{
    public class PostTaskDto
    {
        public string Name { get; set; } = String.Empty;
        public DateTime Deadline { get; set; }
        public string Author { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
