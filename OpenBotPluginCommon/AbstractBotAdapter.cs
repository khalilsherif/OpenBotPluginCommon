using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    public abstract class AbstractBotAdapter : MarshalByRefObject, IBotAdapter
    {
        public abstract string ChannelName { get; }
        public abstract IChatUser CurrentUser { get; }
        public abstract IChatUser[] UserList { get; }

        public abstract IDbConnection GetDatabase(int index);
        public abstract string GetFilePath(int index);
        public abstract bool RequestOAuthKey(out string oauthKey, string reason = "");
        public abstract void SendCommand(string command);
        public abstract void SendMessage(string message);

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
