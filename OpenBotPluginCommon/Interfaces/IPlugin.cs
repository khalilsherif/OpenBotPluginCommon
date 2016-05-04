using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Interfaces
{
    /// <summary>
    /// The base interface for plugins. You must inherit the MarshalByRefObject class if you manually implement this interface.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// The name of the plugin.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The description of the plugin.
        /// </summary>
        string Description { get; }
        /// <summary>
        /// An array of factory instances for IChatHandler's
        /// </summary>
        IChatHandlerFactory[] ChatHandlerFactories { get; }
        /// <summary>
        /// An array of factory instances for IService's
        /// </summary>
        IServiceFactory[] ServiceFactories { get; }
        /// <summary>
        /// Called by the plugin manager to indicate the plugin has been loaded.
        /// </summary>
        /// <returns>Returns true if the load is successful, else return false.</returns>
        bool LoadPlugin();
        /// <summary>
        /// Called by the plugin manager to indicate the plugin is about to be unloaded.
        /// </summary>
        void UnloadPlugin();
    }
}
