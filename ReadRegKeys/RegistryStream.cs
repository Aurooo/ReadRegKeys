using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    public class RegistryStream
    {
        
        public Dictionary<string, string> Read(string path)
        {
            IReadRegistry registryReader = new RegistryFactory().GetBaseKey(path);
            return registryReader.Read(path);
        }
    }
}
