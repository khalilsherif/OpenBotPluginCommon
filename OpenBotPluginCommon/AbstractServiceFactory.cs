﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBot.Plugins.Interfaces;

namespace OpenBot.Plugins
{
    public abstract class AbstractServiceFactory : MarshalByRefObject, IServiceFactory
    {
        public abstract IService Create();
    }
}
