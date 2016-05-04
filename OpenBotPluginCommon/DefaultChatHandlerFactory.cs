using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    public class DefaultChatHandlerFactory<T> : MarshalByRefObject, IChatHandlerFactory where T : IChatHandler, new()
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return "";
            }
        }

        public bool SingleInstance
        {
            get
            {
                return false;
            }
        }

        public DefaultChatHandlerFactory()
        {
            _name = typeof(T).Name;
        }

        public DefaultChatHandlerFactory(string name)
        {
            _name = name;
        }

        public virtual IChatHandler Create()
        {
            return new T();
        }
    }
}
