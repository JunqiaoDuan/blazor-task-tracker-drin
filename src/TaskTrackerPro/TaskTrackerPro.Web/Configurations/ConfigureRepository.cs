using Microsoft.EntityFrameworkCore;
using TaskTrackerPro.Infrastructure.Db.EF;
using TaskTrackerPro.Service.Shared.Repository;

namespace TaskTrackerPro.Web.Configurations
{
    public static class ConfigureRepository
    {
        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
        {
            InjectContext(builder);
            InjectRepository(builder);

            return builder;
        }

        #region inject context

        public static void InjectContext(WebApplicationBuilder builder)
        {
            InjectContext_Default(builder);
        }


        public static void InjectContext_Default(WebApplicationBuilder builder)
        {
            var sqlConnection = builder.Configuration["ConnectionStrings:SqlServerDb"];

            #region Service Repository

            builder.Services.AddDbContext<TaskTrackerProContext>(options =>
                options.UseSqlServer(sqlConnection)
            );
        }

        #endregion

        #endregion

        #region reject repository

        public static void InjectRepository(WebApplicationBuilder builder)
        {

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));

        }

        #endregion
    }
}
