using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Interfaces
{
    public interface IChatUser
    {
        string Username { get; }
        bool Moderator { get; }
        DateTime TimeJoined { get; }
        bool Streamer { get; }
        string Channel { get; }
    }
}
