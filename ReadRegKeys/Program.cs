using System;
using System.Collections.Generic;
using Microsoft.Win32;


namespace ReadRegKeys
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Registry key to read:");
            string regKeyPath = Console.ReadLine();

            RegistryStream reader = new RegistryStream();

            List<Element> keyElements = reader.Read(regKeyPath);

            foreach (var element in keyElements)
            {
                Console.WriteLine(element.Name + ": " + element.Value);
            }
            Console.Read();
        }
    }
}
