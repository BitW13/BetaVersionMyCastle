using TaskPlannerService.PL.Severities;
using TaskPlannerService.PL.TaskCards;
using TaskPlannerService.PL.TaskCategories;

namespace TaskPlannerService.PL
{
    public interface IPresenterLayer
    {
        ITaskCardPresenter Cards { get; set; }

        ITaskCategoryPresenter Categories { get; set; }

        ISeverityPresenter Severities { get; set; }
    }
}
