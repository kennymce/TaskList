using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class TaskListStatusItem
    {
        [Key]
        public int TaskStatusId { get; set; }

        [Required]
        [StringLength(30)]
        public string StatusName { get; set; }
    }
}