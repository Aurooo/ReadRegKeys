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

            var pathArray = path.Split('\\');

            var subKeyIndex = path.IndexOf(BaseKey.Name);
            var subKey = path.Substring(subKeyIndex + BaseKey.Name.Length + 1);



            using (RegistryKey regKey = BaseKey.OpenSubKey(subKey))
            {
                string[] keyNames = regKey.GetValueNames();
                foreach (var name in keyNames)
                    key[name] = regKey.GetValue(name).ToString();
            }
            return key;
        }
    }
}
