using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class RegistryStream
    {
        
        public Dictionary<string, string> Read(string path)
        {
            IReadRegistry registryReader = new RegKeyFactory().OpenBaseKey(path);
            return registryReader.Read(path);
        }
    }
}
