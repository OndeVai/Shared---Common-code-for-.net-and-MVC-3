#region

using System.Collections.Generic;
using Shared.Infrastructure.Location.Dto;

#endregion

namespace Shared.Infrastructure.Location.Service
{
    public interface IStateProvinceService
    {
        string ResourcePath { get; set; }
        IEnumerable<State> GetStates();
        bool ExistsForId(int stateId);
    }
}