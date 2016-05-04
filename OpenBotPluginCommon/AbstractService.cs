using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    public abstract class AbstractService : MarshalByRefObject, IService
    {
        public abstract string Description { get; }
        public abstract bool HasPreferences { get; }
        public abstract string Name { get; }
        public abstract bool LoadService();
        public abstract void ShowPreferences();
        public abstract void UnloadService();
    }
}
