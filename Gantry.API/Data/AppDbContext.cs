using Gantry.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gantry.API.Data
{
    public sealed class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<Kanban> KanbanBoards { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gantry.API.Models.Task>().ToTable("Tasks");

        }

    }

    public sealed class ApplicationUser : IdentityUser
    {
        public bool EnableNotifications { get; set; }
    }
}
