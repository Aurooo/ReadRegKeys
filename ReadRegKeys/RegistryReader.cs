using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ReadRegKeys
{
    abstract class RegistryReader : IReadRegistry
    {
        public Dictionary<string, string> key;
        public RegistryKey BaseKey { get; set; }
        public RegistryReader()
        {
            key = new Dictionary<string, string>();
        }
        public Dictionary<string, string> ReadRegKey(string path)
        {
            
            using (RegistryKey regKey = BaseKey.OpenSubKey(path))
            {
                string[] keyNames = regKey.GetValueNames();
                foreach (var name in keyNames)
                    key[name] = regKey.GetValue(name).ToString();
            }
            return key;
        }
    }
}
