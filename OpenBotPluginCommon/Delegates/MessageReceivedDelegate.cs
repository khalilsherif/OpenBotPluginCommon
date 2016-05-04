using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins.Delegates
{
    public delegate bool MessageReceivedDelegate(IChatUser sender, string message, string[] args, string raw, bool handled);
}
