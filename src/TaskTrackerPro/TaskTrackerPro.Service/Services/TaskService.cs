using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;
using TaskTrackerPro.Service.Interfaces;
using TaskTrackerPro.Service.Shared.Repository;
using TaskTrackerPro.Service.Specifications.TaskItems;

namespace TaskTrackerPro.Service.Services
{
    public class TaskService : ITaskService
    {
        #region fields

        private readonly IRepository<TaskItem> _taskItemRepository;

        #endregion

        #region constructor

        public TaskService(IRepository<TaskItem> taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        #endregion

        #region Public methods

        public async Task<List<TaskItem>> GetAllFilterredAsync(string? title, string? description, TaskItemStatus? taskStatus, TaskItemPriority? taskPriority)
        {
            var spec = new TaskItemListSpec(title, description, taskStatus, taskPriority);
            return await _taskItemRepository.ListAsync(spec);
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            var spec = new TaskItemByIdSpec(id);
            return await _taskItemRepository.FirstOrDefaultAsync(spec);
        }

        public async Task AddAsync(TaskItem task)
        {
            task.Id = Guid.NewGuid();
            task.PrepareForCreate();

            await _taskItemRepository.AddAsync(task);
        }

        public async Task UpdateAsync(TaskItem task)
        {
            var dbTask = await GetByIdAsync(task.Id);

            if (dbTask != null)
            {
                dbTask.Title = task.Title;
                dbTask.Description = task.Description;
                dbTask.TaskItemStatus = task.TaskItemStatus;
                dbTask.TaskItemPriority = task.TaskItemPriority;
                dbTask.PrepareForEdit();

                await _taskItemRepository.UpdateAsync(dbTask);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbTask = await GetByIdAsync(id);
            if (dbTask != null)
            {
                dbTask.PrepareForDelete("Deleted by user");

                await _taskItemRepository.UpdateAsync(dbTask);
            }
        }

        public async Task ToggleCompletionAsync(Guid id, TaskItemStatus taskItemStatus)
        {
            var dbTask = await GetByIdAsync(id);
            if (dbTask != null)
            {
                dbTask.TaskItemStatus = taskItemStatus;
                dbTask.PrepareForEdit();

                await _taskItemRepository.UpdateAsync(dbTask);
            }
        }

        #endregion

    }
}
