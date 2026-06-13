using Microsoft.EntityFrameworkCore;
using sprintCanvas.Models;

namespace sprintCanvas.Data
{
    public class KanbanDbContext : DbContext
    {
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; } = null!;
        public DbSet<BoardColumn> BoardColumns { get; set; } = null!;
        public DbSet<SprintTask> SprintTasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed a default board with three columns (To Do / In Progress / Done)
            modelBuilder.Entity<Board>().HasData(new Board { Id = 1, Name = "Default Board" });
            modelBuilder.Entity<BoardColumn>().HasData(
                new BoardColumn { Id = 1, BoardId = 1, Name = "To Do", Order = 1 },
                new BoardColumn { Id = 2, BoardId = 1, Name = "In Progress", Order = 2 },
                new BoardColumn { Id = 3, BoardId = 1, Name = "Done", Order = 3 }
            );
        }
    }
}
