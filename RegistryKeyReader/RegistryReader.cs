using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegistryKeyReader
{
    abstract class RegistryReader : IReadRegistry
    {
        protected readonly RegistryKey BaseKey;
        protected RegistryReader(RegistryKey baseKey)
        {
            BaseKey = baseKey ?? throw new ArgumentNullException(nameof(baseKey));
        }


        public IEnumerable<RegistryValueElement> Read(string path)
        {
            var keyElements = new List<RegistryValueElement>();

            var baseKeyIndex = path.IndexOf(BaseKey.Name);
            var subKey = path.Substring(baseKeyIndex + BaseKey.Name.Length + 1);



            using (RegistryKey Key = BaseKey.OpenSubKey(subKey))
            {
                string[] names;

                try
                {
                    names = Key.GetValueNames();
                }catch(NullReferenceException ex)
                {
                    throw new Exception("Not an exsisting key");
                }

                foreach (var name in names)
                {
                    var valueKind = Key.GetValueKind(name);

                    if (valueKind == RegistryValueKind.Binary)
                        throw new NotImplementedException("Binary type is not supported");

                    keyElements.Add(new RegistryValueElement
                    {
                        Name = name,
                        Value = Key.GetValue(name).ToString(),
                        ValueType = Key.GetValueKind(name)
                    });
                }
            }
            return keyElements;
        }
    }
}
