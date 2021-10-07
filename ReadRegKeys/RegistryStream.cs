using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class RegistryStream
    {
        
        public List<Element> Read(string path)
        {
            IReadRegistry registryReader = new RegistryFactory().GetBaseKey(path);
            return registryReader.Read(path);
        }
    }
}
