using System;
using GrainInterfaces;
using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;

namespace Host
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Host";
            
            var silo = new SiloHost("TestSilo");
            silo.ConfigFileName = "OrleansConfiguration.xml";
            silo.InitializeOrleansSilo();
            silo.StartOrleansSilo();

            Console.WriteLine("Silo started.");

            

            Console.WriteLine("\nPress Enter to terminate...");
            Console.ReadLine();

            
            silo.ShutdownOrleansSilo();
        }
    }
}
