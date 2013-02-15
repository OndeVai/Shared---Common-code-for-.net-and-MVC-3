#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Shared.Infrastructure.Caching.Adapters;

#endregion

namespace Shared.Infrastructure.Location.Service.Impl
{
    public class USXmlStateProvinceService : IStateProvinceService
    {
        private readonly ICacheAdapter _cacheAdapter;

        public USXmlStateProvinceService(ICacheAdapter cacheAdapter)
        {
            _cacheAdapter = cacheAdapter;
        }

        #region IStateProvinceService Members

        public IEnumerable<State> GetStates()
        {
            var cacheKey = GetType().FullName + "_states";
            return _cacheAdapter.GetCachedItem(cacheKey, 10000, GetStatesInternal);
        }

        public bool ExistsForId(int stateId)
        {
            return GetStates().Any(s => s.Id == stateId);
        }

        public string ResourcePath { get; set; }

        #endregion

        private IEnumerable<State> GetStatesInternal()
        {
            //todo if resource path...
            XDocument statesXml;

            if (string.IsNullOrWhiteSpace(ResourcePath))
            {
                var statesXmlPath =
                    GetType().Assembly.GetManifestResourceNames().FirstOrDefault(s => s.Contains("States.xml"));

                if (string.IsNullOrWhiteSpace(statesXmlPath))
                    throw new InvalidOperationException("States resource not found");

                using (var stream = GetType().Assembly.GetManifestResourceStream(statesXmlPath))
                {
                    statesXml = XDocument.Load(stream);
                }
            }
            else
            {
                statesXml = XDocument.Load(ResourcePath);
            }


            if (statesXml.Root == null) throw new InvalidOperationException("States data not not resolved");

            return statesXml.Root.Elements()
                            .Select(stateEle => new State((int) stateEle.Attribute("Id"),
                                                          (string) stateEle.Attribute("NameAbbr"),
                                                          (string) stateEle.Attribute("NameFull")))
                            .OrderBy(s => s.Id)
                            .ToList();
        }
    }
}