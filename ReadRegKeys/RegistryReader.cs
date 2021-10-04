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
        protected readonly RegistryKey BaseKey;
        protected RegistryReader(RegistryKey key)
        {
            BaseKey = key ?? throw new ArgumentNullException(nameof(key));
        }
        public Dictionary<string, string> ReadRegKey(string path)
        {
            var key = new Dictionary<string, string>();

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
