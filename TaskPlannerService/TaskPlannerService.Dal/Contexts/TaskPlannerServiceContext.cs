using Common.Entity.TaskPlannerService;
using Microsoft.EntityFrameworkCore;

namespace TaskPlannerService.Dal.Contexts
{
    public class TaskPlannerServiceContext : DbContext
    {
        public TaskPlannerServiceContext(DbContextOptions<TaskPlannerServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<TaskCategory> Categories { get; set; }

        public DbSet<Severity> Severities { get; set; }
    }
}
