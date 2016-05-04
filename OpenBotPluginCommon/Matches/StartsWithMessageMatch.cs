using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Matches
{
    public class StartsWithMessageMatch : AbstractMessageMatch
    {
        private string _startToMatch;

        public StartsWithMessageMatch(string startToMatch)
        {
            _startToMatch = startToMatch;
        }

        public override string MatchValue
        {
            get
            {
                return _startToMatch;
            }
        }

        public override bool Match(string message)
        {
            return message.StartsWith(_startToMatch);
        }
    }
}
