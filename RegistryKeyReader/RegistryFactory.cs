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
        public IRegistryReader GetBaseKey(string path)
        {
            if (!IsValidPath(path))
                throw new Exception("Insert a valid key");

            string baseKey = path.Split('\\').Where(x => x.Contains("HKEY"))
                   .Select(x => x.Substring(INDEX_OF_BASE_KEY_NAME))
                   .SingleOrDefault().ToString();


            switch (baseKey.ToString())
            {
                case "CURRENT_USER":
                    return new CurrentUserRegistryReader();

                case "CLASSES_ROOT":
                    return new ClassesRootRegistryReader();

                case "LOCAL_MACHINE":
                    return new LocalMachineRegistryReader();

                case "USERS":
                    return new UsersRegistryReader();

                case "CURRENT_CONFIG":
                    return new CurrentConfigRegistryReader();

                default: throw new Exception($"No registry key found");

            }

        }

        private bool IsValidPath(string path)
        {
            return path.Contains("\\") && path.Split('\\').Any(x => x.Contains("HKEY"));
        }
    }
}
