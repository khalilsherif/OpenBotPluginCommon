using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Interfaces
{
    /// <summary>
    /// The base interface for services. You must inherit the MarshalByRefObject class if you manually implement this interface.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// The name of the service.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The description of the service.
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Indicates that the specified service has a preferences page
        /// </summary>
        bool HasPreferences { get; }
        /// <summary>
        /// Called by the plugin manager to indicate the service has been loaded.
        /// </summary>
        /// <returns>Returns true if the load is successful, else return false.</returns>
        bool LoadService();
        /// <summary>
        /// Called by the plugin manager to indicate the service is about to be unloaded.
        /// </summary>
        void UnloadService();

        /// <summary>
        /// Shows the preferences page, if exists
        /// </summary>
        void ShowPreferences();
    }
}
