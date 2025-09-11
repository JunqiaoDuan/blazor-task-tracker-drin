using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskTrackerPro.Service.Specifications.TaskItems
{
    public class TaskItemByIdSpec : Specification<TaskItem>
    {
        public TaskItemByIdSpec(Guid? id)
        {
            Query.Where(i => i.Id == id && i.IsValid == true);
        }
    }
}
