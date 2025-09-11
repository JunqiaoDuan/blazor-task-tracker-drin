using Microsoft.AspNetCore.Components;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;
using TaskTrackerPro.Service.Interfaces;
using TaskTrackerPro.Service.Shared.Helpers;
using TaskTrackerPro.Web.ViewModels;

namespace TaskTrackerPro.Web.Components
{
    public partial class TaskEdit : ComponentBase
    {
        #region Parameters

        [Parameter] public Guid? TaskItemId { get; set; }
        [Parameter] public EventCallback OnSaved { get; set; }
        [Parameter] public EventCallback OnCancel { get; set; }

        #endregion

        #region Properties

        private TaskItemViewModel_Record _taskItemViewModel = new();

        #endregion

        #region Component Functions

        protected override async Task OnInitializedAsync()
        {
            // edit
            if (TaskItemId.HasValue)
            {
                var dbTaskItem = await _taskService.GetByIdAsync(TaskItemId.Value);
                if (dbTaskItem != null)
                {
                    _taskItemViewModel = ReflectionHelper.CopyTo<TaskItem, TaskItemViewModel_Record>(dbTaskItem);
                }
            }
            // add
            else
            {
                _taskItemViewModel = new TaskItemViewModel_Record
                {
                    TaskItemStatus = TaskItemStatus.Pending,
                    TaskItemPriority = TaskItemPriority.Medium
                };
            }
        }

        #endregion

        #region Event

        private async Task HandleValidSubmit()
        {
            // Update
            if (TaskItemId.HasValue)
            {
                var dbTaskItem = await _taskService.GetByIdAsync(TaskItemId.Value);
                if (dbTaskItem != null)
                {
                    dbTaskItem.Title = _taskItemViewModel.Title;
                    dbTaskItem.Description = _taskItemViewModel.Description;
                    dbTaskItem.TaskItemStatus = _taskItemViewModel.TaskItemStatus;
                    dbTaskItem.TaskItemPriority = _taskItemViewModel.TaskItemPriority;

                    await _taskService.UpdateAsync(dbTaskItem);
                }
            }
            // Add
            else
            {
                var newTaskItem = new TaskItem
                {
                    Title = _taskItemViewModel.Title,
                    Description = _taskItemViewModel.Description,
                    TaskItemStatus = _taskItemViewModel.TaskItemStatus,
                    TaskItemPriority = _taskItemViewModel.TaskItemPriority
                };

                await _taskService.AddAsync(newTaskItem);
            }

            if (OnSaved.HasDelegate)
            {
                await OnSaved.InvokeAsync();
            }
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
