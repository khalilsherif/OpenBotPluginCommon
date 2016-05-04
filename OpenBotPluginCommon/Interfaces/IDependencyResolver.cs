using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Interfaces
{
    /// <summary>
    /// Used to resolve dependencies for IService instances. You must inherit the MarshalByRefObject class if you manually implement this interface.
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolves IService dependencies by the full type name
        /// </summary>
        /// <param name="typeName">The Type.FullName of the target type</param>
        /// <returns>Instance of the type if exists, else null.</returns>
        IService ResolveService(string typeName);
    }
}
