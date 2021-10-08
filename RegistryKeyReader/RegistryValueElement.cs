using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryKeyReader
{
    public class RegistryValueElement
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public RegistryValueKind ValueType { get; set; }
    }
}


