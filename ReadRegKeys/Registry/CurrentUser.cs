﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class CurrentUser : RegistryReader
    {
        public CurrentUser() : base(Registry.CurrentUser)
        {
        }
    }
}