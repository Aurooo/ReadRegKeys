using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryKeyReader
{
    public interface IRegistryReader
    {
        IEnumerable<RegistryValueElement> Read(string path);
    }
}
