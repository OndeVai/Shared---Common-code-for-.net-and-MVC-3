#region

using System;

#endregion

namespace Shared.Application.Query
{
    public class QueryInvalidException : ApplicationException
    {
        public QueryInvalidException(string message) : base(message)
        {
        }
    }
}