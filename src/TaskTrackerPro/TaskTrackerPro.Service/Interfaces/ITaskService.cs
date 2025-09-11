using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;

namespace TaskTrackerPro.Service.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(Guid id);
        Task ToggleCompletionAsync(Guid id, TaskItemStatus taskItemStatus);
    }
}
