using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class RegKeyReader : RegistryReader
    {
        const int INDEX_OF_BASE_KEY_NAME = 5;
        const int ESCAPE = 1;
        public Dictionary<string, string> Read(string regKeyPath)
        {
            
            string[] inputSplitRegKey = regKeyPath.Split('\\');
            foreach (var keyName in inputSplitRegKey)
            {

                if (keyName.Contains("HKEY"))
                {
                    int baseKeyIndexInPath = regKeyPath.IndexOf(keyName);
                    switch (keyName.Substring(INDEX_OF_BASE_KEY_NAME))
                    {
                        case "CURRENT_USER":
                            BaseKey = Registry.CurrentUser;
                            key = ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "CLASSES_ROOT":
                            BaseKey = Registry.ClassesRoot;
                            key = ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "LOCAL_MACHINE":
                            BaseKey = Registry.LocalMachine;
                            key = ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "USERS":
                            BaseKey = Registry.Users;
                            key = ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                        case "CURRENT_CONFIG":
                            BaseKey = Registry.CurrentConfig;
                            key = ReadRegKey(regKeyPath.Substring(baseKeyIndexInPath + keyName.Length + ESCAPE));
                            break;
                    }
                }
            }
            return key;
        }
    }
}
