using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryKeyReader
{
    class RegistryFactory
    {
        const int INDEX_OF_BASE_KEY_NAME = 5;
        public IReadRegistry GetBaseKey(string path)
        {
            if (!IsValidPath(path))
                throw new Exception("Insert a valid key");

            string baseKey = path.Split('\\').Where(x => x.Contains("HKEY"))
                   .Select(x => x.Substring(INDEX_OF_BASE_KEY_NAME))
                   .SingleOrDefault().ToString();


            switch (baseKey.ToString())
            {
                case "CURRENT_USER":
                    return new CurrentUser();

                case "CLASSES_ROOT":
                    return new ClassesRoot();

                case "LOCAL_MACHINE":
                    return new LocalMachine();

                case "USERS":
                    return new Users();

                case "CURRENT_CONFIG":
                    return new CurrentConfig();

                default: throw new Exception($"No registry key found");

            }

        }

        private bool IsValidPath(string path)
        {
            return path.Contains("\\") && path.Split('\\').Any(x => x.Contains("HKEY"));
        }
    }
}
