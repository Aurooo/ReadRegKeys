using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ReadRegKeys
{
    class RegKeyReader
    {
        public Dictionary<string, string> Key { get; private set; }
        public RegKeyReader()
        {
            Key = new Dictionary<string, string>();
        }
        public Dictionary<string, string> Read(string regKeyPath)
        {
            
            string[] inputSplitRegKey = regKeyPath.Split('\\');
            foreach (var item in inputSplitRegKey)
            {

                if (item.Contains("HKEY"))
                {
                    int baseKeyIndexInPath = regKeyPath.IndexOf(item);
                    switch (item.Substring(5))
                    {
                        case "CURRENT_USER":
                            Key = GetCurrentUserRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "CLASSES_ROOT":
                            Key = GetClassesRootRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "LOCAL_MACHINE":
                            Key = GetLocalMachineRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "USERS":
                            Key = GetUsersRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                        case "CURRENT_CONFIG":
                            Key = GetCurrentConfigRegKey(regKeyPath.Substring(baseKeyIndexInPath + item.Length + 1));
                            break;
                    }
                }
            }
            return Key;
        }


        private static Dictionary<string, string> GetCurrentUserRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path))
            {
                string[] keyNames = regKey.GetValueNames();
                foreach (var name in keyNames)
                    key[name] = regKey.GetValue(name).ToString();
            }
            return key;
        }

        private static Dictionary<string, string> GetClassesRootRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(path))
            {
                string[] keyNames = regKey.GetValueNames();
                foreach (var name in keyNames)
                    key[name] = regKey.GetValue(name).ToString();
            }
            return key;
        }

        private static Dictionary<string, string> GetLocalMachineRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(path))
            {
                string[] keyNames = regKey.GetValueNames();
                foreach (var name in keyNames)
                    key[name] = regKey.GetValue(name).ToString();
            }
            return key;
        }

        private static Dictionary<string, string> GetUsersRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.Users.OpenSubKey(path))
            {
                string[] keyNames = regKey.GetValueNames();
                foreach (var name in keyNames)
                    key[name] = regKey.GetValue(name).ToString();
            }
            return key;
        }

        private static Dictionary<string, string> GetCurrentConfigRegKey(string path)
        {
            Dictionary<string, string> key = new Dictionary<string, string>();
            using (RegistryKey regKey = Registry.CurrentConfig.OpenSubKey(path))
            {
                string[] keyNames = regKey.GetValueNames();
                foreach (var name in keyNames)
                    key[name] = regKey.GetValue(name).ToString();
            }
            return key;
        }
    }
}
