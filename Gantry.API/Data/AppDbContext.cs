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
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gantry.API.Models.Task>().ToTable("Tasks");
        }

    }
}
