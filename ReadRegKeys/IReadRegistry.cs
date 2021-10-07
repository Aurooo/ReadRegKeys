using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadRegKeys
{
    public interface IReadRegistry
    {
        Dictionary<string, string> Read(string path);
    }
}
