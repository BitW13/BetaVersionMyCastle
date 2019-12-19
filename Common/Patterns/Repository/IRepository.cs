using System.Collections.Generic;

namespace Common.Patterns.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetItemById(int id);

        void Create(T item);

        void Update(T item);

        bool Delete(int id);
    }
}
