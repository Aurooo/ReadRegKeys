using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class RegKeyReader
    {
        public Dictionary<string, string> Read(string regKeyPath)
        {
            Dictionary<string, string> regKey = new Dictionary<string, string>();
            string[] inputSplitRegKey = regKeyPath.Split('\\');
            foreach (var item in inputSplitRegKey)
            {
                int baseKeyIndexInPath = regKeyPath.IndexOf(item);
                if (item.Contains("HKEY"))
                {
                    switch (item.Substring(5))
                    {
                        case "CURRENT_USER":
                            regKey = GetCurrentUserRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "CLASSES_ROOT":
                            regKey = GetClassesRootRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "LOCAL_MACHINE":
                            regKey = GetLocalMachineRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "USERS":
                            regKey = GetUsersRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "CURRENT_CONFIG":
                            regKey = GetCurrentConfigRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                    }
                }
            }
            return regKey;
        }


        private static Dictionary<string, string> GetCurrentUserRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path))
            {
                string[] names = regKey.GetValueNames();
                foreach (var name in names)
                    key[name] = (string)regKey.GetValue(name);
            }
            return key;
        }

        private static Dictionary<string, string> GetClassesRootRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(path))
            {
                string[] names = regKey.GetValueNames();
                foreach (var name in names)
                    key[name] = (string)regKey.GetValue(name);
            }
            return key;
        }


        private static Dictionary<string, string> GetLocalMachineRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(path))
            {
                string[] names = regKey.GetValueNames();
                foreach (var name in names)
                    key[name] = (string)regKey.GetValue(name);
            }
            return key;
        }

        private static Dictionary<string, string> GetUsersRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.Users.OpenSubKey(path))
            {
                string[] names = regKey.GetValueNames();
                foreach (var name in names)
                    key[name] = (string)regKey.GetValue(name);
            }
            return key;
        }

        private static Dictionary<string, string> GetCurrentConfigRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.CurrentConfig.OpenSubKey(path))
            {
                string[] names = regKey.GetValueNames();
                foreach (var name in names)
                    key[name] = (string)regKey.GetValue(name);
            }
            return key;
        }
    }
}
