using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Interfaces
{
    public interface IMessageMatch
    {
        string MatchValue { get; }
        bool Match(string message);
    }
}
