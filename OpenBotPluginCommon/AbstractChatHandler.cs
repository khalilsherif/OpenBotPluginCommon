using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenBot.Plugins.Interfaces;
using OpenBot.Plugins.Delegates;

namespace OpenBot.Plugins
{
    /// <summary>
    /// Abstract class implementation of the IChatHandler interface. This class exends MarshalByRefObject
    /// </summary>
    public abstract class AbstractChatHandler : MarshalByRefObject, IChatHandler
    {
        public abstract Dictionary<IMessageMatch, MessageReceivedDelegate> MessageHandlers { get; }
        public abstract Dictionary<IMessageMatch, RawCommandReceivedDelegate> RawCommandHandlers { get; }
        public virtual void Created() { }
        public virtual void Destroyed() { }
        public virtual bool HasPreferences { get { return false; } }
        public virtual void ShowPreferences() { }
    }
}
