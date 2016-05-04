using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins.Delegates
{
    /// <summary>
    /// Used in combination with the PluginAssemblyProxy to resolve dependencies from other AppDomains
    /// </summary>
    /// <param name="handlerType">The type of dependency to resolve</param>
    /// <returns>The IService dependency instance if available. Returns null if the dependency cannot be resolved.</returns>
    public delegate IService DependencyResolverDelegate(Type handlerType);

}
