using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Interfaces
{
    /// <summary>
    /// The base handler factory interface. This should never be manually implemented.
    /// </summary>
    public interface IHandlerFactory
    {
        /// <summary>
        /// If true, the plugin manager will only ever create one instance at once.
        /// </summary>
        bool SingleInstance { get; }
        /// <summary>
        /// The name of the handler.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The description of the handler.
        /// </summary>
        string Description { get; }
    }
}
