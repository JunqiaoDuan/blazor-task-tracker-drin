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
        public TaskItemListSpec()
        {
            Query.Where(i => i.IsValid == true);
        }
    }
}
