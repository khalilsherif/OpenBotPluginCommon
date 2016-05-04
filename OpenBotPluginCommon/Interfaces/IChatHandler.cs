using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Delegates;

namespace OpenBot.Plugins.Interfaces
{
    /// <summary>
    /// The base interface for chat handler functionality. You must inherit the MarshalByRefObject class if you manually implement this interface.
    /// </summary>
    public interface IChatHandler
    {
        void Created();
        void Destroyed();
        bool HasPreferences { get; }
        Dictionary<IMessageMatch, MessageReceivedDelegate> MessageHandlers { get; }
        Dictionary<IMessageMatch, RawCommandReceivedDelegate> RawCommandHandlers { get; }
        void ShowPreferences();
    }
}
