using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegistryKeyReader
{
    class LocalMachineRegistryReader : BaseRegistryReader
    {
        public LocalMachineRegistryReader() : base(Registry.LocalMachine)
        {
        }
    }
}
