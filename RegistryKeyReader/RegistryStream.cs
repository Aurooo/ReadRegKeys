using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace RegistryKeyReader
{
    public class RegistryStream
    {
        
        public IEnumerable<RegistryValueElement> Read(string path)
        {
            IRegistryReader registryReader = new RegistryFactory().GetBaseKey(path);
            return registryReader.Read(path);
        }
    }
}
