using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Matches
{
    public class AbsoluteMessageMatch : AbstractMessageMatch
    {
        private string _message;

        public AbsoluteMessageMatch(string messageToMatch)
        {
            _message = messageToMatch;
        }

        public override string MatchValue
        {
            get
            {
                return _message;
            }
        }

        public override bool Match(string message)
        {
            return (_message == message);
        }
    }
}
