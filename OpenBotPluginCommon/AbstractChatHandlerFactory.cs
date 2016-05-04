using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    /// <summary>
    /// Abstract class implementation of the IChatHandlerFactory interface. This class exends MarshalByRefObject
    /// </summary>
    public abstract class AbstractChatHandlerFactory : MarshalByRefObject, IChatHandlerFactory
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract bool SingleInstance { get; }
        public abstract IChatHandler Create();
    }
}
