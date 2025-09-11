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
        private bool _isLoading = true;

        private bool _showEditModal = false;
        private Guid? _editingTaskId = null;

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

            _isLoading = false;
        }

        #endregion

        #region Event

        private void openAddModal()
        {
            _editingTaskId = null;
            _showEditModal = true;
        }

        private void openEditModalClicked(Guid taskId)
        {
            _editingTaskId = taskId;
            _showEditModal = true;
        }

        private void closeEditModal()
        {
            _showEditModal = false;
        }

        private async Task onTaskSavedAsync()
        {
            _showEditModal = false;
            await loadTaskItemsAsync();
        }

        private async Task toggleCompletionClicked(Guid taskId)
        {
            await _taskService.ToggleCompletionAsync(taskId, TaskItemStatus.Completed);

            await loadTaskItemsAsync();
        }

        private async Task openDeleteTaskClicked(Guid taskId)
        {
            await _taskService.DeleteAsync(taskId);

            await loadTaskItemsAsync();
        }

        private async Task onSearchClicked()
        {
            await loadTaskItemsAsync();
        }

        private async Task onClearClicked()
        {
            _taskItemViewModel.TitleFilter = string.Empty;
            _taskItemViewModel.DescriptionFilter = string.Empty;
            _taskItemViewModel.StatusFilter = null;
            _taskItemViewModel.PriorityFilter = null;

            await loadTaskItemsAsync();
        }

        #endregion

        #region Private Methods

        private async Task loadTaskItemsAsync()
        {
            var allTasks = await _taskService.GetAllFilterredAsync(
                _taskItemViewModel.TitleFilter,
                _taskItemViewModel.DescriptionFilter,
                _taskItemViewModel.StatusFilter,
                _taskItemViewModel.PriorityFilter);

            allTasks = allTasks
                .OrderByDescending(i => i.TaskItemPriority)
                .ThenByDescending(i => i.CreationDate)
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
