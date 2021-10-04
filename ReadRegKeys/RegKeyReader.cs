using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class RegKeyReader
    {
        const int INDEX_OF_BASE_KEY_NAME = 5;
        const int ESCAPE = 1;
        public Dictionary<string, string> Read(string regKeyPath)
        {
            var key = new Dictionary<string, string>();
            
            string[] inputSplitRegKey = regKeyPath.Split('\\');
            foreach (var keyName in inputSplitRegKey)
            {

                if (keyName.Contains("HKEY"))
                {
                    int baseKeyIndexInPath = regKeyPath.IndexOf(keyName);
                    switch (keyName.Substring(INDEX_OF_BASE_KEY_NAME))
                    {
                        case "CURRENT_USER":
                            var cuRegistry = new CurrentUserRegistry();
                            key = cuRegistry.ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "CLASSES_ROOT":
                            var crRegistry = new ClassesRootRegistry();
                            key = crRegistry.ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "LOCAL_MACHINE":
                            var lmRegistry = new LocalMachineRegistry();
                            key = lmRegistry.ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "USERS":
                            var uRegistry = new UsersRegistry();
                            key = uRegistry.ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "CURRENT_CONFIG":
                            var ccRegistry = new CurrentConfigRegistry();
                            key = ccRegistry.ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                    }
                }
            }
            return key;
        }
    }
}
