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
    /// Exposes any necessary methods and variables across AppDomains
    /// </summary>
    public static class API
    {
        internal static DependencyResolverDelegate _resolver;
        internal static IBotAdapter _adapter;
        /// <summary>
        /// An instance of IBotAdapter
        /// </summary>
        public static IBotAdapter Adapter { get { return _adapter; } }

        /// <summary>
        /// Resolves IChatHandler dependencies by specified type
        /// </summary>
        /// <param name="dependencyType">The target type</param>
        /// <returns>Instance of the type if exists, else null.</returns>
        public static IService GetService(Type dependencyType)
        {
            return _resolver(dependencyType);
        }
        /// <summary>
        /// Resolves IChatHandler dependencies by specified type
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <returns>Instance of the type if exists, else null.</returns>
        public static T GetService<T>() where T : class, IService
        {
            return GetService(typeof(T)) as T;
        }

        static API()
        {
            _adapter = null;
            _resolver = null;
        }
    }
}
