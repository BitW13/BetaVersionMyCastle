namespace Common.Entity.TaskPlannerService
{
    public class TaskCard
    {
        public TaskEntity Task { get; set; }

        public TaskCategory TaskCategory { get; set; }

        public Severity Severity { get; set; }
    }
}
