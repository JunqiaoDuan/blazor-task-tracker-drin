using System.ComponentModel.DataAnnotations;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;

namespace TaskTrackerPro.Web.ViewModels
{
    public class TaskItemViewModel
    {
        #region Filter

        #endregion

        #region Grid

        public List<TaskItemViewModel_Record> Records = [];

        #endregion

    }

    public class TaskItemViewModel_Record
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
