#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace ronin.dal
{
    public interface ICrud<T, in TP>
    {
        IQueryable<T> Get();
        T Get(TP id);
        void Save(T item);
        void Remove(TP id);
    }
}