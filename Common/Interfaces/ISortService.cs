using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ISortService<T>
    {
        Task<IEnumerable<T>> GetItemsByLastChangedAsync();
    }
}
