#region

using System.Collections.Generic;
using Shared.Application.Infrastructure.Location.Dto;

#endregion

namespace Shared.Application.Infrastructure.Location.Service
{
    public interface IStateProvinceService
    {
        string ResourcePath { get; set; }
        IEnumerable<State> GetStates();
        bool ExistsForId(int stateId);
    }
}