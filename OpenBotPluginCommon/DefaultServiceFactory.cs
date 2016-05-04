using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    public class DefaultServiceFactory<T> : MarshalByRefObject, IServiceFactory where T : IService, new()
    {
        public IService Create()
        {
            return new T();
        }
    }
}
