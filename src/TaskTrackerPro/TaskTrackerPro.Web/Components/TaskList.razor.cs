using System.Threading.Tasks;
using TaskTrackerPro.Service.Entities.TaskItemAggregate;
using TaskTrackerPro.Service.Shared.Helpers;
using TaskTrackerPro.Web.ViewModels;

namespace TaskTrackerPro.Web.Components
{
    public partial class TaskList
    {
        #region Properties

        private TaskItemViewModel _taskItemViewModel;
        private bool isLoading = true;

        #endregion

        #region Component Functions

        protected override async Task OnInitializedAsync()
        {
            #region Init

            _taskItemViewModel = new TaskItemViewModel();

            #endregion

            #region Load Grid

            await loadTaskItemsAsync();

            #endregion

            isLoading = false;
        }

        #endregion

        #region Event



        #endregion

        #region Private Methods

        private async Task loadTaskItemsAsync()
        {
            var allTasks = await _taskService.GetAllAsync();
            allTasks = allTasks
                .OrderByDescending(t => t.CreationDate)
                .ToList();

            _taskItemViewModel.Records = allTasks
                .Select(i => ReflectionHelper.CopyTo<TaskItem, TaskItemViewModel_Record>(i))
                .ToList();
        }

        private string getPriorityBadge(TaskItemPriority priority) => priority switch
        {
            TaskItemPriority.High => "badge bg-danger",
            TaskItemPriority.Medium => "badge bg-warning text-dark",
            TaskItemPriority.Low => "badge bg-success",
            _ => "badge bg-secondary"
        };

        private string getStatusBadge(TaskItemStatus status) => status switch
        {
            TaskItemStatus.Completed => "badge bg-primary",
            TaskItemStatus.Pending => "badge bg-secondary",
            _ => "badge bg-secondary"
        };

        #endregion
    }
}
