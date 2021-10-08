using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryKeyReader
{
    public interface IReadRegistry
    {
        IEnumerable<RegistryValueElement> Read(string path);
    }
}
