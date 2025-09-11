using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;

namespace TaskTrackerPro.Service.Specifications.TaskItems
{
    public class TaskItemListSpec : Specification<TaskItem>
    {
        public TaskItemListSpec(string? title, string? description, TaskItemStatus? taskStatus, TaskItemPriority? taskPriority)
        {
            Query.Where(i => i.IsValid == true);

            if (!string.IsNullOrWhiteSpace(title))
            {
                Query.Where(i => i.Title.Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                Query.Where(i => i.Description.Contains(description));
            }

            if (taskStatus.HasValue)
            {
                Query.Where(i => i.TaskItemStatus == taskStatus.Value);
            }

            if (taskPriority.HasValue)
            {
                Query.Where(i => i.TaskItemPriority == taskPriority.Value);
            }
        }
    }
}
