using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerPro.Service.Entities.Common;
using TaskTrackerPro.Service.Shared.Repository;

namespace TaskTrackerPro.Service.Entities.TaskItemAggregate
{
    public class TaskItem : BaseEntity, IAggregateRoot
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public TaskItemStatus TaskItemStatus { get; set; } = TaskItemStatus.Pending;

        [Required]
        public TaskItemPriority TaskItemPriority { get; set; } = TaskItemPriority.Medium;
    }
}
