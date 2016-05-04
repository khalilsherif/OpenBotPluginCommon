using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace OpenBot.Plugins.Interfaces
{
    /// <summary>
    /// Provides methods within the bot that API instances should have access to.
    /// </summary>
    public interface IBotAdapter
    {
        /// <summary>
        /// Provides a ADO.NET database connection
        /// </summary>
        /// <returns>An IDbConnection which can be used to interact with the specified file.</returns>
        IDbConnection GetDatabase(int index);

        /// <summary>
        /// Provides a path to store data of variable types.
        /// </summary>
        /// <param name="index">The index of the file being requested.</param>
        /// <returns></returns>
        string GetFilePath(int index);

        /// <summary>
        /// Request the use of the Twitch OAuth key from the client.
        /// </summary>
        /// <param name="oauthKey">If successful, the OAuth key will be stored in this string</param>
        /// <param name="reason">The reason why the OAuth key is requested (default empty)</param>
        /// <returns>True or false, if the operation was successful or not.</returns>
        bool RequestOAuthKey(out string oauthKey, string reason = "");
        /// <summary>
        /// Sends a message to the Twitch chat
        /// </summary>
        /// <param name="message">The message to be sent</param>
        void SendMessage(string message);
        /// <summary>
        /// Sends a raw IRC command to the Twitch IRC.
        /// </summary>
        /// <param name="command">The command to be sent.</param>
        void SendCommand(string command);
        /// <summary>
        /// Gets the name of the channel the bot is currently connected to.
        /// </summary>
        string ChannelName { get; }
        /// <summary>
        /// Gets the IChatUser object of the user that the bot is running under.
        /// </summary>
        IChatUser CurrentUser { get; }
        /// <summary>
        /// Gets a list of all users connected to the chat (excluding the bot)
        /// </summary>
        IChatUser[] UserList { get; }
    }
}
