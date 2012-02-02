#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using ronin.Reflection;

#endregion

namespace ronin.Domain.Validation
{
    public class RulesHelper<TModel>
    {
        public bool CheckEmpty<TProperty>(string propertyVal, Expression<Func<TModel, TProperty>> property,
                                          RulesException<TModel> rulesException)
        {
            if (string.IsNullOrWhiteSpace(propertyVal))
            {
                var propName = TypeHelper.GetPropertyName(property);
                rulesException.ErrorFor(property,
                                        string.Format("{0} is required.", propName));
                return true;
            }
            return false;
        }

        public bool CheckMaxLength<TProperty>(string propertyVal, Expression<Func<TModel, TProperty>> property,
                                              int length, RulesException<TModel> rulesException)
        {
            if (!string.IsNullOrWhiteSpace(propertyVal) && propertyVal.Trim().Length > length)
            {
                var propName = TypeHelper.GetPropertyName(property);
                rulesException.ErrorFor(property,
                                        string.Format("{0} cannot be longer than {1} characters.", propName, length));
                return true;
            }
            return false;
        }

        public bool CheckEmail<TProperty>(string propertyVal, Expression<Func<TModel, TProperty>> property,
                                          int length, RulesException<TModel> rulesException)
        {
            if (!CheckEmpty(propertyVal, property, rulesException))
                return false;

            if (!CheckMaxLength(propertyVal, property, length, rulesException))
                return false;

            const string matchEmailPattern =
                @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            return CheckPattern(propertyVal, property, matchEmailPattern, "Invalid email format", rulesException);
        }

        public bool CheckPattern<TProperty>(string propertyVal, Expression<Func<TModel, TProperty>> property,
                                            string pattern, string message, RulesException<TModel> rulesException)
        {
            if (!Regex.IsMatch(propertyVal, pattern))
            {
                rulesException.ErrorFor(property, message);
                return false;
            }

            return true;
        }

        public static bool CheckProfanity(IEnumerable<string> censoredWords, string text)
        {
            return censoredWords.Count() > 0 ?  new Censor(censoredWords).CensorText(text).Length == 0 : true;
        }

        #region Nested type: Censor

        public class Censor
        {
            public Censor(IEnumerable<string> censoredWords)
            {
                if (censoredWords == null)

                    throw new ArgumentNullException("censoredWords");


                CensoredWords = new List<string>(censoredWords);
            }

            public IList<string> CensoredWords { get; private set; }


            public string CensorText(string text)
            {
                if (text == null)

                    throw new ArgumentNullException("text");


                return CensoredWords.Select(ToRegexPattern).Aggregate(text,
                                                                      (current, regularExpression) =>
                                                                      Regex.Replace(current, regularExpression,
                                                                                    StarCensoredMatch,
                                                                                    RegexOptions.IgnoreCase |
                                                                                    RegexOptions.CultureInvariant));
            }


            private static string StarCensoredMatch(Match m)
            {
                var word = m.Captures[0].Value;


                return new string('*', word.Length);
            }


            private static string ToRegexPattern(string wildcardSearch)
            {
                var regexPattern = Regex.Escape(wildcardSearch);


                regexPattern = regexPattern.Replace(@"\*", ".*?");

                regexPattern = regexPattern.Replace(@"\?", ".");


                if (regexPattern.StartsWith(".*?"))
                {
                    regexPattern = regexPattern.Substring(3);

                    regexPattern = @"(^\b)*?" + regexPattern;
                }


                regexPattern = @"\b" + regexPattern + @"\b";


                return regexPattern;
            }
        }

        #endregion
    }
}