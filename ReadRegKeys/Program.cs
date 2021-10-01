using System;
using System.Collections.Generic;
using Microsoft.Win32;


namespace ReadRegKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> regKey = new Dictionary<string, string>();
            Console.WriteLine("Registry key to read:");
            string regKeyPath = Console.ReadLine();
            RegKeyReader reader = new RegKeyReader();
            
            regKey = reader.Read(regKeyPath);
            if (regKey == null)
            {
                Console.WriteLine("can't find the key");
            }
            else
            {
                foreach (var name in regKey)
                {
                    Console.WriteLine(name);
                }
                Console.Read();
            }
        }
    }
}
