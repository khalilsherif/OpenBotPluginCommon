﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBot.Plugins.Interfaces
{
    /// <summary>
    /// Base factory for creating an instance of an IService. You must inherit the MarshalByRefObject class if you manually implement this interface.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Called by the Plugin Manager to create an instance of the IChatHandler
        /// </summary>
        /// <returns>A new instance of the IChatHandler</returns>
        IService Create();
    }
}
