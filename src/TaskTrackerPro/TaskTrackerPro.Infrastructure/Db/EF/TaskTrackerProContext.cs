using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskTrackerPro.Infrastructure.Db.EF
{
    public class TaskTrackerProContext : DbContext
    {
        public TaskTrackerProContext()
        {
        }

        public TaskTrackerProContext(DbContextOptions<TaskTrackerProContext> options)
            : base(options)
        {
        }

        #region Tables


        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
