using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadRegKeys
{
    interface IReadRegistry
    {
        public Dictionary<string, string> ReadRegKey(string path);
    }
}
