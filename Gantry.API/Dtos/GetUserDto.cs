namespace Gantry.API.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int RoleId { get; set; }
        public List<int> AssignedKanbanId { get; set; } = new List<int>();
        public List<int> AssignedTaskId { get; set; } = new List<int>();
    }
}
