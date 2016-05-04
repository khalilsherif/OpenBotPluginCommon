using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Matches
{
    public class ContainsMessageMatch : AbstractMessageMatch
    {
        private string _valueToMatch;

        public ContainsMessageMatch(string valueToMatch)
        {
            _valueToMatch = valueToMatch;
        }

        public override string MatchValue
        {
            get
            {
                return _valueToMatch;
            }
        }

        public override bool Match(string message)
        {
            return message.Contains(_valueToMatch);
        }
    }
}
