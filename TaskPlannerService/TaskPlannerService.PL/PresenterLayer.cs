using TaskPlannerService.PL.Severities;
using TaskPlannerService.PL.TaskCards;
using TaskPlannerService.PL.TaskCategories;

namespace TaskPlannerService.PL
{
    public class PresenterLayer : IPresenterLayer
    {
        public PresenterLayer(ITaskCardPresenter cards, ITaskCategoryPresenter taskCategories, ISeverityPresenter severities)
        {
            Cards = cards;
            Categories = taskCategories;
            Severities = severities;
        }

        public ITaskCardPresenter Cards { get; set; }
        public ITaskCategoryPresenter Categories { get; set; }
        public ISeverityPresenter Severities { get; set; }
    }
}
