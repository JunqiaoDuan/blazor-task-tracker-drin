using System.ComponentModel.DataAnnotations;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;

namespace TaskTrackerPro.Web.ViewModels
{
    public class TaskItemViewModel
    {
        #region Filter

        public string? TitleFilter { get; set; }
        public string? DescriptionFilter { get; set; }
        public TaskItemStatus? StatusFilter { get; set; }
        public TaskItemPriority? PriorityFilter { get; set; }

        #endregion

        #region Grid

        public List<TaskItemViewModel_Record> Records = [];

        #endregion

    }

    public class TaskItemViewModel_Record
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title must be at most 100 characters")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description must be at most 500 characters")]
        public string Description { get; set; }

        [Required]
        public TaskItemStatus TaskItemStatus { get; set; }

        [Required]
        public TaskItemPriority TaskItemPriority { get; set; }

        public DateTimeOffset? CreationDate { get; set; }
    }

}
