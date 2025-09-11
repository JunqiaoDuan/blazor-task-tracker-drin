using Microsoft.AspNetCore.Components;
using TaskTrackerPro.Web.ViewModels;

namespace TaskTrackerPro.Web.Components
{
    public partial class TaskEdit
    {

        #region Paramters

        [Parameter] public Guid? TaskItemId { get; set; }
        [Parameter] public EventCallback OnSaved { get; set; }
        [Parameter] public EventCallback OnCancel { get; set; }

        #endregion

    }
}
