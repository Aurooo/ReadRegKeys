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
        public List<Element> Read(string path)
        {
            var keyElements = new List<Element>();

            var baseKeyIndex = path.IndexOf(BaseKey.Name);
            var subKey = path.Substring(baseKeyIndex + BaseKey.Name.Length + 1);



            using (RegistryKey Key = BaseKey.OpenSubKey(subKey))
            {
                string[] names = Key.GetValueNames();
                foreach (var name in names)
                {
                    keyElements.Add(new Element
                    {
                        Name = name,
                        Value = Key.GetValue(name).ToString()
                    });
                }
            }
            return keyElements;
        }
    }
}
