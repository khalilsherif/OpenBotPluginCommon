using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OpenBot.Plugins.Matches
{
    public class RegexMessageMatch : AbstractMessageMatch
    {
        private string _pattern;

        public RegexMessageMatch(string pattern)
        {
            _pattern = pattern;
        }

        public override string MatchValue
        {
            get
            {
                return _pattern;
            }
        }

        public override bool Match(string message)
        {
            return Regex.IsMatch(message, _pattern);
        }
    }
}
