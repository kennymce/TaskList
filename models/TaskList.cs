using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(255)]
        public string TaskName { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public System.DateTime DateTimeCreated { get; set; }

        [Required]
        public int TaskStatusId { get; set; }
    }

}