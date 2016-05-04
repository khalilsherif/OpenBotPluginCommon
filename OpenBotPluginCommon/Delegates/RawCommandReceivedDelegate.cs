using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins.Delegates
{
    public delegate bool RawCommandReceivedDelegate(int typeIndex, string[] args, string raw, bool handled);
}