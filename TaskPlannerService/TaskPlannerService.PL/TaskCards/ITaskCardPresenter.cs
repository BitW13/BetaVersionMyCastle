using Common.Entity.TaskPlannerService;
using Common.Patterns.Repository;
using System.Threading.Tasks;

namespace TaskPlannerService.PL.TaskCards
{
    public interface ITaskCardPresenter : IPresenter<TaskEntity, TaskCard>
    {
    }
}
