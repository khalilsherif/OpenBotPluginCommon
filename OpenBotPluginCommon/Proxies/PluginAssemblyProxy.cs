using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OpenBot.Plugins.Interfaces;
using OpenBot.Plugins.Delegates;
using System.Runtime.Remoting.Lifetime;

namespace OpenBot.Plugins.Proxies
{
    public class PluginAssemblyProxy : MarshalByRefObject
    {
        private Assembly _assembly;
        private AssemblyName[] _baseAssemblies;
        private List<IPlugin> _plugins;
        private List<KeyValuePair<string, KeyValuePair<string, IChatHandler>>> _activeChatHandlers;
        private List<IService> _activeServices;
        private IDependencyResolver _dependencyResolver;

        public IPlugin[] Plugins { get { return _plugins.ToArray(); } }
        public IService[] Services { get { return _activeServices.ToArray(); } }
        public IChatHandler[] RunningChatHandlers { get { return _activeChatHandlers.Select(a => a.Value.Value).ToArray(); } }
        public KeyValuePair<string, IChatHandler>[] RunningChatHandlersWithNames { get { return _activeChatHandlers.Select(a => a.Value).ToArray(); } }
        public KeyValuePair<string, KeyValuePair<string, IChatHandler>>[] RunningChatHandlersWithNamesAndFactoryName { get { return _activeChatHandlers.ToArray(); } }
        public AppDomain OperatingDomain { get { return AppDomain.CurrentDomain; } }

        public void LoadAssembly(AssemblyName assembly, AssemblyName[] baseAssemblies)
        {
            OperatingDomain.AssemblyResolve += OperatingDomain_AssemblyResolve;

            _baseAssemblies = baseAssemblies;
            _assembly = AppDomain.CurrentDomain.Load(assembly);

            _activeChatHandlers = new List<KeyValuePair<string, KeyValuePair<string, IChatHandler>>>();
            _activeServices = new List<IService>();
            _plugins = new List<IPlugin>();

            API._resolver = GetDependency;
        }

        public void LoadPlugins()
        {
            foreach (Type i in _assembly.DefinedTypes)
                if (i.IsSubclassOf(typeof(MarshalByRefObject)) && typeof(IPlugin).IsAssignableFrom(i))
                {
                    IPlugin plugin = (IPlugin)OperatingDomain.CreateInstanceAndUnwrap(i.Assembly.FullName, i.FullName);
                    if (plugin.LoadPlugin())
                        _plugins.Add(plugin);
                }
        }

        public void InitializeServices()
        {
            foreach(IPlugin i in Plugins)
            foreach (IServiceFactory u in i.ServiceFactories)
                CreateService(u);
        }

        public void Unload()
        {
            _activeChatHandlers.Clear();
            foreach (IPlugin i in _plugins)
                i.UnloadPlugin();

            foreach (IService i in _activeServices)
                i.UnloadService();
        }

        public bool CreateChatHandler(string name, IHandlerFactory factory)
        {
            IChatHandlerFactory chFactory = factory as IChatHandlerFactory;

            if(chFactory == null)
                return false;

            string factoryTypeName = chFactory.GetType().FullName;
            if (_activeChatHandlers.Where(a => a.Key.Equals(factoryTypeName)).Count() > 0 && chFactory.SingleInstance)
                return false;

            IChatHandler instance = chFactory.Create();

            if (instance == null)
                return false;

            instance.Created();

            _activeChatHandlers.Add(new KeyValuePair<string, KeyValuePair<string, IChatHandler>>(factoryTypeName, new KeyValuePair<string, IChatHandler>(name, instance)));

            return true;
        }
        
        private bool CreateService(IServiceFactory serviceFactory)
        {
            IService instance = serviceFactory.Create();

            if (!instance.LoadService())
                return false;

            _activeServices.Add(instance);

            return true;
        }

        public void RemoveChatHandler(IChatHandler handler)
        {
            if (_activeChatHandlers.Where(a => a.Value.Value == handler).Count() > 0)
                _activeChatHandlers.Remove(_activeChatHandlers.Where(a => a.Value.Value == handler).First());

            handler.Destroyed();
        }

        public void SetAdapter(IBotAdapter adapter)
        {
            API._adapter = adapter;
        }

        public void SetDomainSafeDependencyResolver(IDependencyResolver resolver)
        {
            _dependencyResolver = resolver;
        }

        public bool DefinesType(string typeName)
        {
            return _assembly.DefinedTypes.Where(a => a.FullName == typeName).Count() > 0;
        }

        public IService GetServiceIfExists(string name)
        {
            foreach (IService i in Services)
                if (i.GetType().FullName == name)
                    return i;

            return null;
        }

        public bool HandleMessageIfMatched(IChatUser sender, string message, string[] args, string raw, bool handled)
        {
            foreach (IChatHandler p in RunningChatHandlers)
            {
                if (p.MessageHandlers == null)
                    continue;
                foreach (var u in p.MessageHandlers)
                {
                    if (u.Key.Match(message))
                    {
                        handled = u.Value(sender, message, args, raw, handled) || handled;
                    }
                }
            }

            return handled;
        }
        public bool HandleRawCommandIfMatched(int typeIndex, string[] args, string raw, bool handled)
        {
            foreach (IChatHandler p in RunningChatHandlers)
            {
                if (p.RawCommandHandlers == null)
                    continue;

                foreach (var u in p.RawCommandHandlers)
                {
                    if (u.Key.Match(raw))
                    {
                        handled = u.Value(typeIndex, args, raw, handled) || handled;
                    }
                }
            }

            return handled;
        }

        internal IService GetDependency(Type targetType)
        {
            if (_dependencyResolver == null)
                return null;

            return _dependencyResolver.ResolveService(targetType.FullName);
        }

        private Assembly OperatingDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            foreach (Assembly i in OperatingDomain.GetAssemblies())
                if (i.GetName().FullName == args.Name)
                    return i;

            foreach (AssemblyName i in _baseAssemblies)
                if (i.FullName == args.Name)
                    return Assembly.Load(i);

            return null;
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
