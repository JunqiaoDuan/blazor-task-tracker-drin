using System.ComponentModel.DataAnnotations;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;

namespace TaskTrackerPro.Web.ViewModels
{
    public class TaskItemViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public TaskItemStatus Status { get; set; } = TaskItemStatus.Pending;

        [Required]
        public TaskItemPriority Priority { get; set; } = TaskItemPriority.Medium;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
