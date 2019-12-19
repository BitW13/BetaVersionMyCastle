using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICardService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetItemByIdAsync(int id);
    }
}
