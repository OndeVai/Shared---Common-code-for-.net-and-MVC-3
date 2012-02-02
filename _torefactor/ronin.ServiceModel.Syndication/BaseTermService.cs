using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ronin.ServiceModel.Syndication.Model;

namespace ronin.ServiceModel.Syndication
{
    public abstract class BaseTermService : ITermService
    {
        #region Implementation of ITermService

        public abstract List<Term> ExtractTerms(string context, string query);

        public List<Term> ExtractTerms(string context)
        {
            return ExtractTerms(context, null);
        }

        #endregion
    }
}
