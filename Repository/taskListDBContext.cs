using TaskList.Models;
using Microsoft.EntityFrameworkCore; 
namespace TaskList.TaskListDB

{
    public class TaskListDBContext : DbContext
    {
        public TaskListDBContext(DbContextOptions<TaskListDBContext> options)
            :base(options){}
        public DbSet<TaskItem> taskList {get; set;}
        public DbSet<TaskListStatusItem> taskStatus {get; set;}

    }
}