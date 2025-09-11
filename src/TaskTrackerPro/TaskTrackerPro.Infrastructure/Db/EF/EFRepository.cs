using Ardalis.Specification.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerPro.Service.Shared.Repository;

namespace TaskTrackerPro.Infrastructure.Db.EF
{
    public class EFRepository<T> : RepositoryBase<T>, IRepository<T>, IReadRepository<T>
        where T : class, IAggregateRoot
    {
        public EFRepository(TaskTrackerProContext dbContext) : base(dbContext)
        {

        }
    }
}
