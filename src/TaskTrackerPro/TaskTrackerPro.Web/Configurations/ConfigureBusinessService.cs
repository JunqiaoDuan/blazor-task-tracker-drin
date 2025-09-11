using TaskTrackerPro.Service.Interfaces;
using TaskTrackerPro.Service.Services;

namespace TaskTrackerPro.Web.Configurations
{
    public static class ConfigureBusinessService
    {
        public static WebApplicationBuilder AddBusinessService(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITaskService, TaskService>();

            return builder;
        }
    }
}
