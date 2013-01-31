#region

using System;
using WebApi.Hal;
using System.Linq;

#endregion

namespace Shared.Infrastructure.Dto.Hal
{
    public class TokenizedLink : Link
    {
        private readonly int _hrefQueryStringStartPosition = -1;
        private readonly string _origHref;
        private const string HrefSlash = @"/";
        private const string HrefQueryStringStart = @"?";
        private const string HrefQueryStringAppend = @"&";
        private readonly string _hrefQueryString;

        public TokenizedLink(string rel, string href)
            : base(rel, href)
        {
            _origHref = href;
            _hrefQueryStringStartPosition = PositionInHref(HrefQueryStringStart);
            _hrefQueryString = _hrefQueryStringStartPosition > -1 ? _origHref.Substring(_hrefQueryStringStartPosition) : string.Empty;
        }

        public TokenizedLink CreateLink(Func<string, object>[] substitutions, bool removeIfNull = false)
        {
            foreach (var substitution in substitutions)
            {
                CreateLink(substitution, removeIfNull);
            }
            return this;
        }

        public TokenizedLink CreateLink(Func<string, object> substitution, bool removeIfNull = false)
        {

            UpdateHref(substitution, removeIfNull);

            return this;
        }

        public TokenizedLink TemplateWithoutQuerystring()
        {
            Href = _origHref.Replace(_hrefQueryString, string.Empty);
            return this;
        }

        private void UpdateHref(Func<string, object> substitution, bool removeIfNull)
        {
            var subName = substitution.Method.GetParameters()[0].Name.Trim('_');
            var token = string.Format("{{{0}}}", subName);

            if (PositionInHref(token) <= -1) return;

            var val = substitution(null);
            var hasVal = val != null;

            if (hasVal)
            {
                Href = CreateUri(substitution).ToString();
                return;
            }

            if (!removeIfNull) return;

            if (!IsQuerystring(token))
                Href = Href.Replace(token + HrefSlash, string.Empty);
            else
            {
                //remove querystring pairs if remove is true
                if(string.IsNullOrWhiteSpace(_hrefQueryString))
                    return;

                var queryVals =
                    _hrefQueryString.Split(new[] { HrefQueryStringStart, HrefQueryStringAppend },
                                       StringSplitOptions.None).ToList();
                queryVals.RemoveAll(v => v.Contains(token));

                var newQueryVals = string.Join(HrefQueryStringAppend, queryVals);

                Href = Href.Replace(_hrefQueryString, string.Empty);
                if (!string.IsNullOrWhiteSpace(newQueryVals))
                    Href = Href + HrefQueryStringStart + newQueryVals;
            }
        }


        private bool IsQuerystring(string token)
        {
            if (_hrefQueryStringStartPosition < 0) return false;
            return PositionInHref(token) > _hrefQueryStringStartPosition;
        }

        private int PositionInHref(string searchFor)
        {
            return PositionIn(searchFor, _origHref);
        }

        private static int PositionIn(string searchFor, string searchIn)
        {
            return searchIn.IndexOf(searchFor, StringComparison.Ordinal);
        }


    }
}