#region

using System;
using WebApi.Hal;

#endregion

namespace Shared.Infrastructure.Dto.Hal
{
    public class LinkSegment
    {
        private readonly bool _hasPrevious;
        private readonly bool _isQuerystring;
        private readonly bool _replaceIfNull;
        private readonly Func<string, object> _substitution;
        private readonly string _token;

        public LinkSegment(string token, Func<string, object> substitution, bool replaceIfNull = false,
                           bool hasPrevious = false, bool isQuerystring = false)
        {
            _isQuerystring = isQuerystring;
            _token = token;
            _substitution = substitution;
            _replaceIfNull = replaceIfNull;
            _hasPrevious = hasPrevious;
        }

        public override string ToString()
        {
            var val = _substitution(null);
            var hasVal = val != null;

            if (_replaceIfNull && !hasVal)
                return string.Empty;

            var after = !_isQuerystring ? "/" : string.Empty;
            var before = _isQuerystring ? (!_hasPrevious ? "?" : "&") : string.Empty;
            var valResolved = hasVal ? new Link("", _token).CreateUri(_substitution).ToString() : _token;
            return string.Format("{0}{1}{2}", before, valResolved, after);
        }
    }
}