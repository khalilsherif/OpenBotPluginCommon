using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    /// <summary>
    /// Abstract class implementation of the IPlugin interface. This class exends MarshalByRefObject
    /// </summary>
    public abstract class AbstractPlugin : MarshalByRefObject, IPlugin
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract IChatHandlerFactory[] ChatHandlerFactories { get; }
        public abstract IServiceFactory[] ServiceFactories { get; }
        public abstract bool LoadPlugin();
        public abstract void UnloadPlugin();
    }
}
