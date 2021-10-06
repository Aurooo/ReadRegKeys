using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class RegKeyReader
    {
        
        public Dictionary<string, string> Read(string regKeyPath)
        {
            IReadRegistry registryReader = new RegKeyFactory().OpenBaseKey(regKeyPath);
            return registryReader.ReadRegKey(regKeyPath);
        }
    }
}
