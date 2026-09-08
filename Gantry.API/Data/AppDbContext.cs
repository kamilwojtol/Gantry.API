using Gantry.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Gantry.API.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Kanban> KanbanBoards { get; set; }
    }
}
