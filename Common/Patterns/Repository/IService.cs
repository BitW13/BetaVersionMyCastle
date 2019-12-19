using System.Collections.Generic;

namespace Common.Patterns.Repository
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();

        T GetItemById(int id);

        T Create(T item);

        void Update(T item);

        bool Delete(int id);
    }
}
