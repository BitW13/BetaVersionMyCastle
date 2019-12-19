using System.Collections.Generic;

namespace Common.Patterns.Repository
{
    public interface IPresenter<Input, Output>
    {
        IEnumerable<Output> GetAll();

        Output GetItemById(int id);

        Output Create(Input item);

        Output Update(Input item);

        bool Delete(int id);
    }
}
