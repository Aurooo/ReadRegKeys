using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadRegKeys
{
    class RegKeyFactory
    {
        const int INDEX_OF_BASE_KEY_NAME = 5;
        public IReadRegistry OpenBaseKey(string path)
        {

            var baseKeyName = path.Split('\\').Where(x => x.Contains("HKEY"))
                .Select(x => x.Substring(INDEX_OF_BASE_KEY_NAME))
                .SingleOrDefault().ToString();
            
            switch (baseKeyName.ToString())
            {
                case "CURRENT_USER":
                    return new CurrentUserRegistry();

                case "CLASSES_ROOT":
                    return new ClassesRootRegistry();

                case "LOCAL_MACHINE":
                    return new LocalMachineRegistry();

                case "USERS":
                    return new UsersRegistry();

                case "CURRENT_CONFIG":
                    return new CurrentConfigRegistry();

                default: throw new Exception($"No base key found for {nameof(path)}");

            }

        }
    }
}
