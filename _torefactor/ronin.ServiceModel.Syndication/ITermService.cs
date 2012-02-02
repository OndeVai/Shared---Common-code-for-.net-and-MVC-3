using System.Collections.Generic;
using ronin.ServiceModel.Syndication.Model;

namespace ronin.ServiceModel.Syndication
{
    public interface ITermService
    {
         List<Term> ExtractTerms(string context, string query);
         List<Term> ExtractTerms(string context);
    }
}