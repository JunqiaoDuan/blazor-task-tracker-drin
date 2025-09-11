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
        public TaskItemStatus TaskItemStatus { get; set; }

        [Required]
        public TaskItemPriority TaskItemPriority { get; set; }

        public DateTimeOffset? CreationDate { get; set; }
    }

}
