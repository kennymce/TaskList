using Microsoft.EntityFrameworkCore;
using TaskList.Models;

namespace TaskList.Repository
{
    public class TaskListDatabaseContext : DbContext
    {
        public DbSet<TaskItem> TaskList { get; set; }
        public DbSet<TaskListStatusItem> TaskListStatus { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add default value for DateTimeCreated column
            modelBuilder.Entity<TaskItem>()
                .Property(t => t.DateTimeCreated)
                .HasDefaultValueSql("getdate()");

            // Seed data
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { TaskId = 1,TaskName = "First task", Description = "First task description", TaskStatusId = 1},
                new TaskItem { TaskId = 2, TaskName = "Second task", Description = "Second task description", TaskStatusId = 2},
                new TaskItem { TaskId = 3, TaskName = "Third task", Description = "Third task description", TaskStatusId = 3},
                new TaskItem { TaskId = 4, TaskName = "Fourth task", Description = "Fourth task description", TaskStatusId = 4}
            );
            
            modelBuilder.Entity<TaskListStatusItem>().HasData(
                new TaskListStatusItem { TaskStatusId = 1, StatusName = "Not Started"},
                new TaskListStatusItem { TaskStatusId = 2, StatusName = "In Progress"},
                new TaskListStatusItem { TaskStatusId = 3, StatusName = "Complete"}
            );            
        }

        public TaskListDatabaseContext (DbContextOptions<TaskListDatabaseContext> options) : base(options) { }
    }
}