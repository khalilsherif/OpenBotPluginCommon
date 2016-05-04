using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    public abstract class AbstractMessageMatch : MarshalByRefObject, IMessageMatch
    {
        public abstract string MatchValue { get; }

        public abstract bool Match(string message);
    }
}
