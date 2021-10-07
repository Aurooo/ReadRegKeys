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
        protected RegistryReader(RegistryKey baseKey)
        {
            BaseKey = baseKey ?? throw new ArgumentNullException(nameof(baseKey));
        }
        public Dictionary<string, string> Read(string path)
        {
            var key = new Dictionary<string, string>();

            var baseKeyIndex = path.IndexOf(BaseKey.Name);
            var subKey = path.Substring(baseKeyIndex + BaseKey.Name.Length + 1);



            using (RegistryKey Key = BaseKey.OpenSubKey(subKey))
            {
                string[] names = Key.GetValueNames();
                foreach (var name in names)
                    key[name] = Key.GetValue(name).ToString();
            }
            return key;
        }
    }
}
